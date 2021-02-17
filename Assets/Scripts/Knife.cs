using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    bool animationComplete = false;
    public CuttingPoints pointsScript;
    public GameObject body;
    public LineRenderer lineRenderer;
    public Transform pos2;
    
    public void Start()
    {
        lineRenderer.SetPosition(0, body.transform.position);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!animationComplete)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, 0.1f);
            lineRenderer.SetPosition(1, body.transform.position);
            if (transform.position == pos2.position)
            {
                animationComplete = true;
                OnAnimationComplete();
            }
        }
    }

    void OnAnimationComplete()
    {
        HideBody();
        pointsScript.OnAnimationComplete();
    }

    void HideBody()
    {
        body.SetActive(false);
    }

    void ShowBody()
    {
        body.SetActive(true);
    }
}
