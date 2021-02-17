using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainWholeNumberMenu : MonoBehaviour
{
    public int currentLevel = 2;
    int currentDialog = 18;

    public Client pizzaGuy;
    public PizzaWholeNumber pizza1;
    public LevelManagerLevel2 level2Menu;

    void Start()
    {
        pizzaGuy.EnableBubble();
    }

    public void EnableMenu()
    {
        gameObject.SetActive(true);
        LoadDialog(currentDialog);
        pizzaGuy.EnableBubble();
    }

    public void DisableMenu()
    {
        gameObject.SetActive(false);
    }

    void LoadDialog(int index)
    {
        switch (index)
        {
            case 18:
                DisplayCurrentDialog(false);
                pizza1.EnablePizza(8, 8);
                break;
            case 19:
                DisplayCurrentDialog(true);
                break;
            case 20:
                DisplayCurrentDialog(true);
                break;
            case 21:
                DisplayCurrentDialog(true);
                break;
            case 22:
                DisplayCurrentDialog(true);
                break;
            case 23:
                level2Menu.OnExplain2Complete();
                DisableMenu();
                break;
            default:
                DisplayCurrentDialog(true);
                break;
        }
    }

    public void DisplayNextDialog(bool showSpeachButtonOnComplete = false)
    {
        currentDialog++;
        string dialogKey = "level_" + currentLevel.ToString() + "_" + currentDialog.ToString();
        DisplayText(dialogKey, showSpeachButtonOnComplete);
    }

    void DisplayCurrentDialog(bool showSpeachButtonOnComplete = false)
    {
        string dialogKey = "level_" + currentLevel.ToString() + "_" + currentDialog.ToString();
        DisplayText(dialogKey, showSpeachButtonOnComplete);
    }

    void DisplayText(string key, bool showSpeachButtonOnComplete = false)
    {
        pizzaGuy.GetComponent<DescriptionTextClient>().DisplayText(key, showSpeachButtonOnComplete);
    }

    public void OnTaskComplete()
    {
        DisplayNextDialog(true);
    }

    public void OnClientCompleteDialog()
    {
        if (!IsActionDialog(currentDialog))
        {
            currentDialog++;
            LoadDialog(currentDialog);
        }
    }

    bool IsActionDialog(int index)
    {
        List<int> actionDialogs = new List<int>();
        actionDialogs.Add(18); actionDialogs.Add(19);
        for (int i = 0; i < actionDialogs.Count; i++)
        {
            if (actionDialogs[i] == index) return true;
        }
        return false;
    }
}
