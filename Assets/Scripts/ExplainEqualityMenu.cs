using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainEqualityMenu : MonoBehaviour
{
    public int currentLevel = 2;
    int currentDialog = 6;

    public Client pizzaGuy;
    public PizzaExplain pizza1;
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
            case 6:
                DisplayCurrentDialog(true);
                break;
            case 7:
                DisplayCurrentDialog(false);
                pizza1.EnablePizza(4, 10);  
                break;
            case 11:
                DisplayCurrentDialog(true);
                pizza1.MakeNewTask(3, 4);
                break;
            case 12:
                DisplayCurrentDialog(false);
                pizza1.EnablePizza(9, 12);
                break;
            case 15:
                level2Menu.OnExplain1Complete();
                DisableMenu();
                break;
            default:
                DisplayCurrentDialog(true);
                break;
        }
    }

    void DisplayNextDialog(bool showSpeachButtonOnComplete = false)
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
        actionDialogs.Add(7);actionDialogs.Add(12);
        for (int i = 0; i < actionDialogs.Count; i++)
        {
            if (actionDialogs[i] == index) return true;
        }
        return false;
    }
}
