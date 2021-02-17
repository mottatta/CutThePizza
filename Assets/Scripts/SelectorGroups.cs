using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorGroups : MonoBehaviour
{
    public GameObject[] selectors;

    public void EbableSelectors(int count)
    {
        int startIndex = Random.Range(0, selectors.Length - 1 - count);
        gameObject.SetActive(true);
        for (int i = 0; i < selectors.Length; i++)
        {
            if(i >= startIndex && i < startIndex + count) selectors[i].SetActive(true);
            else selectors[i].SetActive(false);
        }
    }
}
