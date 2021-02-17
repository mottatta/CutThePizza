using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingLabel : MonoBehaviour
{
    public Text txt;

    public void SetText(string t)
    {
        txt.text = t;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
