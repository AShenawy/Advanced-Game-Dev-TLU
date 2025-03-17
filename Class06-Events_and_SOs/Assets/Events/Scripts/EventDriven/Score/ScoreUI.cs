using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text textScore;

    private void Start()
    {
        ResetScore();

        ScoreManager.OnHiScoreChanged += UpdateScore;
    }

    void ResetScore()
    {
        textScore.text = "0";
    }

    void UpdateScore(int newScore)
    {
        textScore.text = newScore.ToString();
    }
}
