using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using LoLSDK;

using System;

public static class SharedState
{

	// private static int score = 0;
	private static JSONNode startGameData;
	private static JSONNode languageDefs;
	private static MultipleChoiceQuestionList questionList;
	private static int currentQuestionIndex = 0;

    private static int currentProgress = 0;
    private static int totalProgress = 50;

    // public static int Score
    // {
    // 	get
    // 	{
    // 		return score;
    // 	}
    // 	set
    // 	{
    // 		score = value;
    // 	}
    // }
        public static void GameComplete()
        {
            LOLSDK.Instance.CompleteGame();
        }


        public static void SubmitProgress()
        {
            currentProgress++;
            if (currentProgress > totalProgress)
            {
                Debug.LogError("Current progress is greater than total progress " + currentProgress.ToString());
                currentProgress = totalProgress;
            }
            else if (LOLSDK.Instance)
            {
                try
                {
                    LOLSDK.Instance.SubmitProgress(0, currentProgress, totalProgress);
                }
                catch
                {
                    Debug.Log("LOL is not instantiate");
                }
            
            }
            Debug.Log("Submit progress " + currentProgress + "/" + totalProgress);
        }

    public static JSONNode StartGameData
	{
		get
		{
			return startGameData;
		}
		set
		{
			startGameData = value;
		}
	}

	public static JSONNode LanguageDefs
	{
		get
		{
			return languageDefs;
		}
		set
		{
			languageDefs = value;
		}
	}

	public static MultipleChoiceQuestionList QuestionList
	{
		get
		{
			return questionList;
		}
		set
		{
			questionList = value;
		}
	}

	public static MultipleChoiceQuestion GetQuestion() {
		if (questionList != null && questionList.questions != null && currentQuestionIndex < questionList.questions.Length) {
			MultipleChoiceQuestion question = questionList.questions [currentQuestionIndex];
			currentQuestionIndex++;
			return question;
		}

		return null;
	}
}

