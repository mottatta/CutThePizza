using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

public class DescriptionTextClient : DescriptionText
{
    public Client clientScript;
    public override void DisplayText(string key, bool showSpeachButtonOnComplete = false)
    {
        clientScript.EnableBubble();
        txt.text = "";
        if (c != null) StopCoroutine(c);
        c = null;
        string textKey = key;
        if (SharedState.LanguageDefs != null)
        {
            if (SharedState.LanguageDefs[textKey] != null)
            {
                LOLSDK.Instance.SpeakText(textKey);
                c = StartCoroutine(AnimateText(SharedState.LanguageDefs[textKey], showSpeachButtonOnComplete));
            }
        }
        else c = StartCoroutine(AnimateText("Lorem epsum...", showSpeachButtonOnComplete));
    }
    public override IEnumerator AnimateText(string inputText, bool showSpeachButtonOnComplete)
    {
        //gameObject.SetActive(true);
        int i = 0;
        while (i < inputText.Length)
        {
            txt.text += inputText[i];
            i++;
            yield return new WaitForSeconds(delayBetweenLetters);
        }
        
        if (showSpeachButtonOnComplete) speachButton.SetActive(true);
        else clientScript.OnClientCompleteDialog();
    }

    public override void OnSpeachButtonPressed()
    {
        clientScript.DisableBubble();
        clientScript.OnClientCompleteDialog();
    }
}
