using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    Pizza pizza;
    SpriteRenderer sprite;
    bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        pizza = GameObject.FindGameObjectWithTag("pizza").GetComponent<Pizza>();
        sprite = GetComponent<SpriteRenderer>();
        isSelected = false;
        sprite.enabled = false;
    }

    void OnMouseDown()
    {
        if(isSelected == true)
        {
            Unselect();
        }
        else
        {
            Select();
        }
    }

    void Unselect()
    {
        isSelected = false;
        sprite.enabled = false;
        pizza.OnPieceUnselected();
    }

    void Select()
    { 
        isSelected = true;
        sprite.enabled = true;
        pizza.OnPieceSelected();
    }
}
