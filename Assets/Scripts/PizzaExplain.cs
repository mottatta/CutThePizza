using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaExplain : Pizza
{
    public ExplainEqualityMenu explainMenu;
    public GameObject[] objectsToBeDisabled;
    public GameObject[] objectsToBeEnabled;
    public override void EnablePizza(int n, int d)
    {
        SetNumeratorDenominator(n, d);
        ActivateCuttingPizza();
    }

    public override void ActivateCuttingPizza()
    {
        cuttingScript.SetPiecesCount(denominator);
    }

    public override void OnAllPairsComplete(int index)
    {
        explainMenu.OnTaskComplete();
    }

    public void MakeNewTask(int n, int d)
    {
        cuttingScript.DisableAllGroupsButOne(-1);
        DisableObjects();
        EnableObjects();
    }

    public void DisableObjects() {
        foreach(GameObject obj in objectsToBeDisabled){
            obj.SetActive(false);
        }
    }

    public void EnableObjects()
    {
        foreach (GameObject obj in objectsToBeEnabled)
        {
            obj.SetActive(true);
        }
    }
}
