using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaWholeNumber : Pizza
{
    public GameObject disabler;
    public ExplainWholeNumberMenu explainWholeNumberMenu;
    public override void EnablePizza(int n, int d)
    {
        SetNumeratorDenominator(n, d);
        ActivateCuttingPizza();
    }

    public override void OnAllPairsComplete(int index)
    {
        explainWholeNumberMenu.DisplayNextDialog(false);
        ActivateSelectors(index);
    }

    public override void ActivateSelectors(int index)
    {
        selectorGroups[index].SetActive(true);
    }

    public override void ActivateCuttingPizza()
    {
        cuttingScript.SetPiecesCount(denominator);
    }
  
    public override void OnPieceSelected()
    {
        markedPieces++;
        if(markedPieces == denominator)
        {
            disabler.SetActive(true);
            explainWholeNumberMenu.OnTaskComplete();
        }
    }
}
