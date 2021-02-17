using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOkButton : MonoBehaviour
{
    public Pizza pizza;
    public AudioClip clickSound;
    private void OnMouseDown()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(clickSound);
        pizza.OnOkButtonClicked();
    }
}
