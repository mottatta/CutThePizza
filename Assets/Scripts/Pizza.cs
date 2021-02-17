using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public int numerator;
    public int denominator;
    public int markedPieces;
    public CuttingScript cuttingScript;
    public GameObject[] selectorGroups;
    public GameObject okButton;
    public DescriptionText descriptionTxt;
    public MealComposeMenu pizzaMenu;
    public AudioClip selectAudio;

    void Start()
    {
        
    }

    public virtual void EnablePizza(int n, int d)
    {
        descriptionTxt.SetText("");
        markedPieces = 0;
        SetNumeratorDenominator(n, d);
        ActivateCuttingPizza();
        okButton.GetComponent<PizzaOkButton>().pizza = this;
    }

    public void DisableAllSelectors()
    {
        foreach(GameObject selector in selectorGroups)
        {
            selector.SetActive(false);
        }
    }
    
    public void SetNumeratorDenominator(int n, int d)
    {
        numerator = n;
        denominator = d;
    }

    public virtual void ActivateCuttingPizza()
    {
        cuttingScript.SetPiecesCount(denominator);
        descriptionTxt.DisplayText("explain_cutting");
        okButton.SetActive(false);
    }

    public virtual void OnAllPairsComplete(int index)
    {
        ActivateSelectors(index);
    }

    public virtual void ActivateSelectors(int index)
    {
        selectorGroups[index].SetActive(true);
        if(descriptionTxt) descriptionTxt.DisplayText("explain_marking");
    }

    public void OnOkButtonClicked()
    {
        if (markedPieces == numerator) OnPizzaTaskComplete();
        else
        {
            descriptionTxt.DisplayText("marking_error");
        }
    }

    void OnPizzaTaskComplete()
    {
        pizzaMenu.OnTaskComplete();
    }

    public virtual void OnPieceSelected()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(selectAudio);
        markedPieces++;
        if (!okButton.activeInHierarchy) okButton.SetActive(true);
    }

    public void OnPieceUnselected()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(selectAudio);
        markedPieces--;
    }
}
