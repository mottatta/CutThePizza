using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingPoint : MonoBehaviour
{
    public CuttingPoints pointsScript;
    public AudioClip clickAudio;
    private List<KeyCode> keys;
    private List<string> letters;
    private int randomIndex;
    public Text txt;


    public void Start()
    {
        keys = new List<KeyCode>();
        letters = new List<string>();

        keys.Add(KeyCode.A);
        letters.Add("A");

        keys.Add(KeyCode.B);
        letters.Add("B");

        keys.Add(KeyCode.C);
        letters.Add("C");

        keys.Add(KeyCode.D);
        letters.Add("D");

        keys.Add(KeyCode.E);
        letters.Add("E");

        keys.Add(KeyCode.F);
        letters.Add("F");

        keys.Add(KeyCode.G);
        letters.Add("G");

        keys.Add(KeyCode.H);
        letters.Add("H");

        keys.Add(KeyCode.I);
        letters.Add("I");

        keys.Add(KeyCode.J);
        letters.Add("J");

        keys.Add(KeyCode.K);
        letters.Add("K");

        keys.Add(KeyCode.L);
        letters.Add("L");

        keys.Add(KeyCode.M);
        letters.Add("M");

        keys.Add(KeyCode.N);
        letters.Add("N");

        keys.Add(KeyCode.O);
        letters.Add("O");

        keys.Add(KeyCode.P);
        letters.Add("P");

        keys.Add(KeyCode.Q);
        letters.Add("Q");

        keys.Add(KeyCode.R);
        letters.Add("R");

        keys.Add(KeyCode.S);
        letters.Add("S");

        keys.Add(KeyCode.T);
        letters.Add("T");

        keys.Add(KeyCode.U);
        letters.Add("U");

        keys.Add(KeyCode.V);
        letters.Add("V");

        keys.Add(KeyCode.W);
        letters.Add("W");

        keys.Add(KeyCode.X);
        letters.Add("X");

        keys.Add(KeyCode.Y);
        letters.Add("Y");

        keys.Add(KeyCode.Z);
        letters.Add("Z");

        randomIndex = Random.Range(0, keys.Count - 1);
        txt.text = letters[randomIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(keys[randomIndex]))
        {
            PulsePointCollected();
        }
    }

    void PulsePointCollected()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(clickAudio);
        pointsScript.OnPointClicked();
        gameObject.SetActive(false);
    }

    /*
    private void OnMouseDown()
    {
        if (SoundManager.GetInstance()) SoundManager.GetInstance().PlaySFX(clickAudio);
        pointsScript.OnPointClicked();
        gameObject.SetActive(false);
    }
    */
}
