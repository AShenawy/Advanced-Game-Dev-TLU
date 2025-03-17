using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int hiScore;
    public int winningScore = 1000000;


    // An event that can pass a value (int) when raised
    public static event UnityAction<int> OnNewHiscore;

    public static event UnityAction OnScoreZero;
    public static event UnityAction OnWinScore;

    public void UpdateScore(int amount)
    {
        currentScore += amount;

        if (currentScore > hiScore)
        {
            print("New hi-score reached! " + currentScore);
            hiScore = currentScore;

            // Invoke the event and provide an int value, as defined by the event type above: UnityAction<int>
            OnHiScoreChanged?.Invoke(hiScore);
        }
        else if (currentScore <= 0)
		{
			// Invoke if the player score goes down to zero
            OnScoreZero?.Invoke();
		}

        if (currentScore >= winningScore)
        {
			// Invoke if the player score passes the winning score
            OnWinScore?.Invoke();
        }
    }
}
