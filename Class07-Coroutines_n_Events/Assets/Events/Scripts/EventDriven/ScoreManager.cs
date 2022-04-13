using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int hiScore;

    public static UnityAction OnScoreZero;
    public static UnityAction<int> OnHiScoreChanged;

    public void UpdateScore(int amount)
    {
        currentScore += amount;

        if (currentScore > hiScore)
        {
            hiScore = currentScore;
            OnHiScoreChanged?.Invoke(hiScore);
        }
        else if (currentScore <= 0)
        {
            OnScoreZero?.Invoke();
        }
    }
}
