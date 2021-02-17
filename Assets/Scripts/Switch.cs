using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public Sprite[] sprites;
    public Switch[] targets;
    public bool isEndSwitch = false;
    public Vector2 fraction;
    public SpriteRenderer rendererObj;
    int currentTargetIndex = 0;
    public Animator raysAnimator;
    public AudioClip clickAudio;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ChangeSwitchDirection();
    }

    private void ChangeSwitchDirection()
    {
        currentTargetIndex++;
        if (currentTargetIndex >= targets.Length) currentTargetIndex = 0;
        ChangeSprite(currentTargetIndex);
    }

    private void ChangeSprite(int num)
    {
        rendererObj.sprite = sprites[num];
        if (SoundManager.GetInstance() && sprites.Length > 1) SoundManager.GetInstance().PlaySFX(clickAudio);
    }

    public Switch GetTarget()
    {
        return targets[currentTargetIndex];
    }

    public void ShowRays()
    {
        raysAnimator.Play("RaysRotate");
    }
}
