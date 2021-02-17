using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaBox : MonoBehaviour
{
    public int numerator;
    public int denominator;
    public float value;
    public Text txt;
    public Animator raysAnimator;

    void Start()
    {
        txt.text = numerator.ToString() + "/" + denominator.ToString();
        value = denominator / numerator;
    }

    public void ShowRays()
    {
        raysAnimator.Play("RaysRotate");
    }
}
