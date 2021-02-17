using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPoints : MonoBehaviour
{
    int pointsClicked = 0;
    public GameObject[] points;
    public GameObject knife;
    public CuttingPointsGroup groupScript;

    public void OnPointClicked()
    {
        pointsClicked++;
        if (pointsClicked >= 2) knife.SetActive(true);
    }

    public void OnAnimationComplete()
    {
        groupScript.OnPairAnimationComplete();
    }

    public void EnableGameObject()
    {
        gameObject.SetActive(true);
        EnablePoints();
    }

    void EnablePoints()
    {
        foreach(GameObject point in points)
        {
            point.SetActive(true);
        }
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
