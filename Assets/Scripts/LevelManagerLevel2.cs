using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerLevel2 : MonoBehaviour
{
    public Client boy;
    public Client pizzaGuy;
    public ExplainEqualityMenu explainEqualityMenu;
    public ExplainWholeNumberMenu explainWholeNumberMenu;
    public TransitionScript transition;

    int currentDialog = 1;

    void Start()
    {
        boy.DisableBubble();
        pizzaGuy.DisableBubble();
        boy.GoIn();
    }

    public void GoToNextSpeach()
    {

    }

    void DisplayNextDialog()
    {
        currentDialog++;
        string dialogKey = "level_2_" + currentDialog.ToString();
        DisplayText(dialogKey, true);
    }

    void DisplayCurrentDialog()
    {
        string dialogKey = "level_2_" + currentDialog.ToString();
        DisplayText(dialogKey, true);
    }

    void DisplayText(string key, bool showSpeachButtonOnComplete = false)
    {
        GetCurrentClient().EnableBubble();
        GetCurrentClient().GetComponent<DescriptionText>().DisplayText(key, showSpeachButtonOnComplete);
    }

    Client GetCurrentClient()
    {
        switch (currentDialog)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 15:
            case 16:
            case 23:
                return boy;
            case 17:
            case 24:
            case 25:
                return pizzaGuy;
            default:
                return pizzaGuy;
        }
    }

    public void OnExplain1Complete()
    {
        SharedState.SubmitProgress();
        currentDialog = 15;
        DisplayCurrentDialog();
    }

    public void OnExplain2Complete()
    {
        SharedState.SubmitProgress();
        currentDialog = 23;
        DisplayCurrentDialog();
    }

    public void OnClientMoveInComplete()
    {
        string dialogKey = "level_2_" + currentDialog.ToString();
        DisplayText(dialogKey, true);
    }

    public void OnClientCompleteDialog()
    {
        if (IsActionDialog(currentDialog))
        {
            if (currentDialog == 5) explainEqualityMenu.EnableMenu();
            else explainWholeNumberMenu.EnableMenu();
        }
        else if(currentDialog == 24)
        {
            EndLevel();
        }
        else
        {
            DisplayNextDialog();
        }
    }

    void EndLevel()
    {
        transition.DisplayTransitionAndGotoNextScene();
    }

    bool IsActionDialog(int index)
    {
        List<int> actionDialogs = new List<int>();
        actionDialogs.Add(5); actionDialogs.Add(17);
        for (int i = 0; i < actionDialogs.Count; i++)
        {
            if (actionDialogs[i] == index) return true;
        }
        return false;
    }
}
