using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMealMenu : MonoBehaviour
{
    public BuyMealButton[] buttons;

    public void ShowHint(string type)
    {
        foreach (BuyMealButton button in buttons)
        {
            if (button.type == type) button.ShowHint();
        }
    }

    public void ActivateButtons()
    {
        foreach(BuyMealButton button in buttons)
        {
            button.SetButtonActive();
            button.HideHint();
        }
    }

    public void DeactivateButtons()
    {
        foreach (BuyMealButton button in buttons)
        {
            button.SetButtonInactive();
            button.HideHint();
        }
    }
}
