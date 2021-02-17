using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPointsGroup : MonoBehaviour
{
    public CuttingPoints[] pairs;
    public CuttingScript cuttingScript;
    int currentPair = 0;

    void Start()
    {
        DisableGroupsButOne(currentPair);
    }

    void DisableGroupsButOne(int index)
    {
        for(int i = 0; i < pairs.Length; i++)
        {
            if (i == index) pairs[i].EnableGameObject();
            else pairs[i].DisableGameObject();
        }
    }

    public void OnPairAnimationComplete()
    {
        currentPair++;
        if (currentPair >= pairs.Length)
        {
            OnAllPairsComplete();
        }
        else pairs[currentPair].gameObject.SetActive(true);
    }

    public void EnableGameObject()
    {
        gameObject.SetActive(true);
        DisableGroupsButOne(currentPair);
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnAllPairsComplete()
    {
        cuttingScript.OnAllPairsComplete();
    }
}
