using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPizza : MonoBehaviour
{
    public Pizza pizza;

    string orderType;
    int numerator;
    int denominator;

    int currentDialog = 1;
    int currentOrder = 0;
    public MealOrder orders;
    public Client boy;
    public Client girl;
    public Client currentClient;
    public BuyMealMenu buyMealMenu;
    public MealComposeMenu hamPizzaMenu;
    public MealComposeMenu vegetarianPizzaMenu;
    public MealComposeMenu cakeMenu;
    public MealComposeMenu currentComposeMenu;
    public TransitionScript transition;

    void Start()
    {
        boy.DisableBubble();
        girl.DisableBubble();
        currentClient = boy;
        LoadDialog(currentDialog);
    }

    void LoadDialog(int index)
    {
        switch (index)
        {
            case 1:
                boy.GoIn();
                CreateOrder(currentOrder);
                break;
            case 2:
                DisplayCurrentDialog();
                break;
            case 3:
                DisplayCurrentDialog();
                break;
            case 4:
                DisplayCurrentDialog();
                break;
            case 5:
                DisplayCurrentDialog();
                break;
            case 6:
                DisplayCurrentDialog();
                break;
        }
    }

    void DisplayNextDialog()
    {
        currentDialog++;
        string dialogKey = "level_1_" + currentDialog.ToString();
        DisplayText(dialogKey);
    }

    void DisplayCurrentDialog()
    {
        string dialogKey = "level_1_" + currentDialog.ToString();
        DisplayText(dialogKey);
    }

    void DisplayText(string key)
    {
        currentClient.GetComponent<DescriptionText>().DisplayText(key);
    }

    void CreateOrder(int index)
    {
        orderType = orders.types[index];
        numerator = (int) orders.numDenom[index].x;
        denominator = (int) orders.numDenom[index].y;
        currentComposeMenu = GetCurrentComposeMenu();
    }

    public void OnMealButtonPressed(string t)
    {
        if(t != orderType)
        {
            DisplayText("level_1_error");
            Invoke("AfterErrorMessage", 4f);
        }
        else
        {
            CancelInvoke("AfterErrorMessage");
            buyMealMenu.DeactivateButtons();
            currentComposeMenu.EnableMenu(numerator, denominator);
        }
    }

    void AfterErrorMessage()
    {
        if (!currentComposeMenu.gameObject.activeInHierarchy) DisplayCurrentDialog();
    }

    public void OnTaskComplete()
    {
        SharedState.SubmitProgress();
        currentOrder++;
        currentDialog++;
        if(currentOrder < orders.types.Length) CreateOrder(currentOrder);
        LoadDialog(currentDialog);
    }

    MealComposeMenu GetCurrentComposeMenu()
    {
        switch (orderType)
        {
            case "ham_pizza":
                return hamPizzaMenu;
            case "vegetarian_pizza":
                return vegetarianPizzaMenu;
            case "cake":
                return cakeMenu;
        }
        return null;
    }

    public void OnClientMoveInComplete()
    {
        string dialogKey = "level_1_" + currentDialog.ToString();
        DisplayText(dialogKey);
    }

    public void OnClientCompleteDialog()
    {
        if (IsActionDialog(currentDialog))
        {
            ActivateBuyMealMenu();
        }
        else
        {
            switch (currentDialog)
            {
                case 3:
                    currentDialog++;
                    SwitchClients(boy, girl);
                    break;
                case 6:
                    currentClient.GoOut();
                    Invoke("EndLevel", 1f);
                    break;
            }
        }
    }

    void EndLevel()
    {
        transition.DisplayTransitionAndGotoNextScene();
    }

    void SwitchClients(Client clientOut, Client clientIn)
    {
        currentClient = clientIn;
        clientOut.GoOut();
        clientIn.GoIn();
    }

    void ActivateBuyMealMenu()
    {
        buyMealMenu.ActivateButtons();
        buyMealMenu.ShowHint(orderType);
    }

    bool IsActionDialog(int index)
    {
        List<int> actionDialogs = new List<int>();
        actionDialogs.Add(1);actionDialogs.Add(2);actionDialogs.Add(4);actionDialogs.Add(5);
        for(int i = 0; i < actionDialogs.Count; i++)
        {
            if (actionDialogs[i] == index) return true;
        }
        return false;
    }
}
