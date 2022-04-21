using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePaused State", menuName = "State/Game Paused")]
public class GamePausedState : BaseState
{
    public BaseState unpauseState;
    public BaseState quitState;

    public override void Enter()
    {
        base.Enter();

        // Pause all game actions
        Time.timeScale = 0;
        GameManager.instance.pauseGameUI.gameObject.SetActive(true);
    }

    public override void Process()
    {
        base.Process();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            nextState = unpauseState;
            Exit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            nextState = quitState;
            Exit();
        }
    }

    public override void Exit()
    {
        GameManager.instance.pauseGameUI.gameObject.SetActive(false);

        base.Exit();
    }
}
