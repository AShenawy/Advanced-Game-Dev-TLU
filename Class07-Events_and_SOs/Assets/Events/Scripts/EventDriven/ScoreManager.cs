using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int hiScore;

    public static event UnityAction OnScoreZero;

    // An event that can pass a value (int) when raised
    public static event UnityAction<int> OnHiScoreChanged;

    public void UpdateScore(int amount)
    {
        currentScore += amount;

        if (currentScore > hiScore)
        {
            hiScore = currentScore;

            // Invoke the event and provide an int value, as defined by the event type above: UnityAction<int>
            OnHiScoreChanged?.Invoke(hiScore);
        }
        else if (currentScore <= 0)
        {
            OnScoreZero?.Invoke();
        }
    }
}
