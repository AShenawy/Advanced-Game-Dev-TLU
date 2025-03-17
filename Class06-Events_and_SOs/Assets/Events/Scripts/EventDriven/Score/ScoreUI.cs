using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text textScore;

    private void Awake()
    {
		// Subscribe to the event
        ScoreManager.OnNewHiscore += SetScore;
    }

    // Update the high score UI when a new highscore is reached
    private void Start()
    {
        ResetScore();
    }

    void ResetScore()
    {
        textScore.text = "000";
    }

    void SetScore(int newScore)
    {
        textScore.text = newScore.ToString();
    }

    private void OnDestroy()
    {
		// Unsubscribe from the event
        ScoreManager.OnNewHiscore -= SetScore;
    }
}
