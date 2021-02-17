using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PreLevelManager : MonoBehaviour
{
    public DescriptionText descriptionText;
    public TransitionScript transition;

    public int currentDialog = 1;
    public int currentLevel = 1;
    public int dialogsCount = 3;
    int lastLevel = 4;

    // Start is called before the first frame update
    void Start()
    {
        DisplayDialog(currentDialog);
    }

    public void OnClientCompleteDialog()
    {
        currentDialog++;
        if (currentDialog > dialogsCount) EndScene();
        else DisplayDialog(currentDialog);
    }

    void DisplayDialog(int i)
    {
        string key = "pre_level_" + currentLevel.ToString() + "_" + currentDialog.ToString();
        descriptionText.DisplayText(key, true);
    }

    void EndScene()
    {
        if (currentLevel == lastLevel) SharedState.GameComplete();
        transition.DisplayTransitionAndGotoNextScene();
    }
}
