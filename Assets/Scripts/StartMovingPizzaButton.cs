using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovingPizzaButton : MonoBehaviour
{
    public LevelManagerLevel4 levelManager;
    public AudioClip clickAudio;

    private void OnMouseDown()
    {
        levelManager.OnStartMovingPizzaButtonClicked();
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(clickAudio);
    }
}
