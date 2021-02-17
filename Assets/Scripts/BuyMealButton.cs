using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMealButton : MonoBehaviour
{
    public string type;
    public LevelManagerPizza levelManager;
    public GameObject glow;
    public GameObject hint;
    bool isButtonActive = false;
    public AudioClip soundClick;
    
    void Start()
    {
        glow.SetActive(false);
        HideHint();
    }

    public void SetButtonActive()
    {
        isButtonActive = true;
    }

    public void SetButtonInactive()
    {
        isButtonActive = false;
    }

    void OnMouseDown()
    {
        if (isButtonActive)
        {
            if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(soundClick);
            levelManager.OnMealButtonPressed(type);
            HideHint();
        }
    }

    void OnMouseEnter()
    {
        if (isButtonActive)
        {
            glow.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        glow.SetActive(false);
    }

    public void ShowHint()
    {
        hint.SetActive(true);
    }

    public void HideHint()
    {
        hint.SetActive(false);
    }
}
