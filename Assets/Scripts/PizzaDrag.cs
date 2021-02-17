using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaDrag : MonoBehaviour
{
    public Vector3 originalPos;
    Vector3 targetPos = Vector3.zero;
    float moveSpeed = 5f;
    float moveSpeedDrop = 30f;
    public Text txt;
    public int numerator;
    public int denominator;
    public int value;

    PizzaBox currentPizzaBox = null;
    public Selectors selectors;
    public GameObject[] lines;
    bool isCollidingWithBox = false;
    bool isOnRightAnswer = false;
    bool isDragged;
    public LevelManagerLevel3 levelManager;

    public AudioClip successAudio;
    public AudioClip failAudio;

    void Start()
    {
        
    }

    public void SetPizzaStayPosition(Vector3 pos)
    {
        originalPos = pos;
        targetPos = pos;
    }

    public void SetNumDenom(int num, int denom)
    {
        numerator = num;
        denominator = denom;
        txt.text = num.ToString() + "/" + denom.ToString();
        value = denominator / numerator;
        int linesIndex = GetLinesIndex(denominator);
        lines[linesIndex].SetActive(true);
        selectors.SetSelectorNumDenom(num, linesIndex);
    }

    int GetLinesIndex(int n)
    {
        List<int> vals = new List<int>();
        vals.Add(2); vals.Add(3); vals.Add(4); vals.Add(5); vals.Add(6); vals.Add(8); vals.Add(10); vals.Add(12);
        for(int i = 0; i < vals.Count; i++)
        {
            if (vals[i] == n) return i;
        }
        Debug.LogError("Trying to set denominator, which doesn't exist in the possible denominators array!");
        return -1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "pizzaBox")
        {
            PizzaBox box = collider.gameObject.GetComponent<PizzaBox>();
            currentPizzaBox = box;
            isCollidingWithBox = true;
            if (box.value == value) isOnRightAnswer = true;
            else isOnRightAnswer = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "pizzaBox")
        {
            currentPizzaBox = null;
            isCollidingWithBox = false;
            isOnRightAnswer = false;
        }
    }

    public void OnStartDrag()
    {
        isDragged = true;
        levelManager.OnPizzaStartDrag();
    }

    public void OnDropped()
    {
        isDragged = false;
        moveSpeed = moveSpeedDrop;
        if (!isCollidingWithBox)
        {
            targetPos = originalPos;
        }
        else
        {
            if (currentPizzaBox.value == value)
            {
                if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(successAudio);
                currentPizzaBox.ShowRays();
                levelManager.OnTaskComplete();
                Destroy(gameObject);
            }
            else
            {
                if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(failAudio);
                ShowWrongSymbol();
                targetPos = originalPos;
            }
        }
    }

    void ShowWrongSymbol()
    {
        GameObject.FindGameObjectWithTag("wrongSymbol").GetComponent<Animator>().SetTrigger("Show");
    }

    void Update()
    {
        if(targetPos != Vector3.zero)
        {
            if (transform.position != targetPos && !isDragged)
            {
                Vector3 newPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                transform.position = newPos;
            }
            else if (transform.position == targetPos) levelManager.OnPizzaStay();
        }
    }
}
