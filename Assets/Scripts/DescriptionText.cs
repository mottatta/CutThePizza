using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

public class DescriptionText : MonoBehaviour
{
    public Text txt;
    public float delayBetweenLetters = 0.03f;
    public GameObject speachButton;
    public Coroutine c;

    public virtual void DisplayText(string key, bool showSpeachButtonOnComplete = false)
    {
        txt.text = "";
        if (c != null) StopCoroutine(c);
        c = null;
        string textKey = key;
        if(SharedState.LanguageDefs != null)
        {
            if (SharedState.LanguageDefs[textKey] != null)
            {
                Debug.Log("displayText " + key+" : ");
                LOLSDK.Instance.SpeakText(textKey);
                c = StartCoroutine(AnimateText(SharedState.LanguageDefs[textKey], showSpeachButtonOnComplete));
            }
            Debug.Log("displayText " + key);
        }
        else c = StartCoroutine(AnimateText("Lorem epsum...", showSpeachButtonOnComplete));
    }

    public virtual void ShowTextWithoutDelay(string key, bool showSpeachButtonOnComplete = false, bool speakText = false)
    {
        txt.text = "";
        string textKey = key;
        if (SharedState.LanguageDefs != null)
        {
            if (SharedState.LanguageDefs[textKey] != null)
            {
                if(speakText) LOLSDK.Instance.SpeakText(textKey);
                txt.text = SharedState.LanguageDefs[textKey];
            }
        }
        else txt.text = "Lorem epsum...";
        if (showSpeachButtonOnComplete) speachButton.SetActive(true);
    }

    public virtual IEnumerator AnimateText(string inputText, bool showSpeachButtonOnComplete)
    {
        int i = 0;
        while (i < inputText.Length)
        {
            txt.text += inputText[i];
            i++;
            yield return new WaitForSeconds(delayBetweenLetters);
        }
        if(showSpeachButtonOnComplete) speachButton.SetActive(true);
    }

    public void SetText(string t)
    {
        txt.text = t;
    }

    public virtual void OnSpeachButtonPressed()
    {
        
    }
}
