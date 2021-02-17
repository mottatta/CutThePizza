using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Animator animator;
    public GameObject bubble;
    public LevelManagerPizza levelManager;
    public LevelManagerLevel2 levelManager2;
    public ExplainEqualityMenu explainMenu;
    public ExplainWholeNumberMenu explainWholeNumberMenu;
    public PreLevelManager preLevelManager;
    public AudioClip bellAudio;
    void Start()
    {
        
    }

    public void GoIn()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(bellAudio);
        bubble.SetActive(false);
        animator.Play("Client_WalkIn");
    }

    public void OnGoInComplete()
    {
        bubble.SetActive(true);
        if (levelManager) levelManager.OnClientMoveInComplete();
        else if (levelManager2) levelManager2.OnClientMoveInComplete();
    }

    public void GoOut()
    {
        bubble.SetActive(false);
        animator.Play("Client_WalkOut");
    }

    public void OnClientCompleteDialog()
    {
        if (levelManager) levelManager.OnClientCompleteDialog();
        else if (levelManager2) levelManager2.OnClientCompleteDialog();
        else if (explainMenu) explainMenu.OnClientCompleteDialog();
        else if (explainWholeNumberMenu) explainWholeNumberMenu.OnClientCompleteDialog();
        else if (preLevelManager) preLevelManager.OnClientCompleteDialog();
    }

    public void EnableBubble()
    {
        bubble.SetActive(true);
    }

    public void DisableBubble()
    {
        bubble.SetActive(false);
    }
}
