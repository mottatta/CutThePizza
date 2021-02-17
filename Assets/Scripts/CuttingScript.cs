using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingScript : MonoBehaviour
{
    public int piecesCount;
    public int piecesIndex;
    public CuttingPointsGroup[] cuttingGroups;
    public Pizza pizza;

    public void SetPiecesCount(int val)
    {
        piecesCount = val;
        List<int> vals = new List<int>();
        vals.Add(2); vals.Add(3); vals.Add(4); vals.Add(5); vals.Add(6); vals.Add(8); vals.Add(10); vals.Add(12);
        for(int i = 0; i < cuttingGroups.Length; i++)
        {
            if (piecesCount == vals[i]) piecesIndex = i;
        }
        DisableAllGroupsButOne(piecesIndex);
    }

    public void DisableAllGroupsButOne(int index)
    {
        for(int i=0; i < cuttingGroups.Length; i++)
        {
            if (index == i) cuttingGroups[i].EnableGameObject();
            else cuttingGroups[i].DisableGameObject();
        }
    }

    public void OnAllPairsComplete()
    {
        pizza.OnAllPairsComplete(piecesIndex);
    }

    public int GetPiecesIndex()
    {
        return piecesIndex;
    }
}
