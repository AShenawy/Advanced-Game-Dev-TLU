using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("States")]
    public BaseState startingState;
    public BaseState currentState;

    [Header("UI")]
    public Text stateTextUI;
    public Text startGameUI;
    public Text pauseGameUI;

    [Header("Game Elements")]
    public ObjectMover goblin;


    // Singleton implementation
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Kick-start the first state
        ChangeState(startingState);
    }

    void Update()
    {
        // Keep the state going
        currentState.Process();
    }

    public void ChangeState(BaseState newState)
    {
        currentState = newState;
        currentState.Enter();

        stateTextUI.text = currentState.state.ToString();
    }

    public void ResetGame()
    {
        goblin.ResetPosition();
    }
}
