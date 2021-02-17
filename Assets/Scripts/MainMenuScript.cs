using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public AudioClip wooshAudio;
    public AudioClip toopAudio;
    
    public void PlayWoosh()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(wooshAudio);
    }

    public void PlayToop()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(toopAudio);
    }
}
