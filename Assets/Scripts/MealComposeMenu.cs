using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealComposeMenu : MonoBehaviour
{
    public string type;
    public Pizza pizza;
    public LevelManagerPizza levelManager;
    public Text orderTxt;
    public GameObject UIElements;

    void EnablePizza(int n, int d)
    {
        pizza.DisableAllSelectors();
        pizza.EnablePizza(n, d);
        string orderString = "Order4e";
        if (SharedState.LanguageDefs != null) orderString = SharedState.LanguageDefs["order"];
        orderTxt.text = orderString + ": \n " + n.ToString() + "/" + d.ToString();
    }

    public void OnTaskComplete()
    {
        DisableMenu();
        levelManager.OnTaskComplete();
    }

    public void EnableMenu(int n, int d)
    {
        gameObject.SetActive(true);
        UIElements.SetActive(true);
        EnablePizza(n, d);
    }

    public void DisableMenu()
    {
        gameObject.SetActive(false);
        UIElements.SetActive(false);
    }
}
