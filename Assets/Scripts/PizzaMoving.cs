using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaMoving : MonoBehaviour
{
    Vector3 targetPos = Vector3.zero;
    float moveSpeed = 5f;
    float originalSpeed = 5f;
    float goBackSpeed = 15f;
    public Text txt;
    public int numerator;
    public int denominator;
    public int solutionNum;
    public int solutionDenom;
    public int value;
    public Vector3 pizzaStayPos;
    public bool isAllowedToMove = true;
    bool isCollidingWithBox = false;
    public bool isPizzaReadyToGo = false;
    PizzaBox currentPizzaBox = null;
    public Selectors selectors;
    public GameObject[] lines;
    public Switch currentSwitch;
 
    bool isOnRightAnswer = false;
    public LevelManagerLevel4 levelManager;

    public AudioClip successAudio;
    public AudioClip failAudio;

    void Start()
    {

    }

    public void SetPizzaTargetPos(Vector3 pos)
    {
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

    public void SetSolution(int num, int denom)
    {
        solutionNum = num;
        solutionDenom = denom;
    }

    int GetLinesIndex(int n)
    {
        List<int> vals = new List<int>();
        vals.Add(2); vals.Add(3); vals.Add(4); vals.Add(5); vals.Add(6); vals.Add(8); vals.Add(10); vals.Add(12);
        for (int i = 0; i < vals.Count; i++)
        {
            if (vals[i] == n) return i;
        }
        Debug.LogError("Trying to set denominator, which doesn't exist in the possible denominators array!");
        return -1;
    }

    void ShowWrongSymbol()
    {
        GameObject.FindGameObjectWithTag("wrongSymbol").GetComponent<Animator>().SetTrigger("Show");
    }

    public void SetAndMoveToSwitch(Switch s)
    {
        SetPizzaTargetPos(s.transform.position);
        currentSwitch = s;
    }

    void Update()
    {
        if (targetPos != Vector3.zero)
        {
            if (transform.position != targetPos)
            {
                Vector3 newPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                transform.position = newPos;
            }
            else if (!isPizzaReadyToGo)
            {
                moveSpeed = originalSpeed;
                isPizzaReadyToGo = true;
                levelManager.CurrentPizzaReadyToGo();
            }
            else if(currentSwitch != null)
            {
                if(!currentSwitch.isEndSwitch)
                {
                    SetAndMoveToSwitch(currentSwitch.GetTarget());
                }
                else
                {
                    //pizza is in box
                    if (IsCorrectPlaced())
                    {
                        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(successAudio);
                        levelManager.OnCorrect();
                        currentSwitch .ShowRays();
                        levelManager.OnTaskComplete();
                        Destroy(gameObject);
                    }
                    else
                    {
                        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(failAudio);
                        ShowWrongSymbol();
                        currentSwitch = null;
                        isPizzaReadyToGo = false;
                        moveSpeed = goBackSpeed;
                        targetPos = pizzaStayPos;
                        levelManager.OnWrong();
                    }
                }
            }
        }
    }

    bool IsCorrectPlaced()
    {
        return (numerator * currentSwitch.fraction.x == solutionNum) && (denominator * currentSwitch.fraction.y == solutionDenom); 
    }
}
