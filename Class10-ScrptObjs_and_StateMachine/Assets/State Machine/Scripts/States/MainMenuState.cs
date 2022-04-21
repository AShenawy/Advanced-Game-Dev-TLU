using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainMenu State", menuName = "State/Main Menu")]
public class MainMenuState : BaseState
{
    public override void Enter()
    {
        base.Enter();

        // Pause all game actions
        Time.timeScale = 0;

        GameManager.instance.startGameUI.gameObject.SetActive(true);
        GameManager.instance.ResetGame();
    }

    public override void Process()
    {
        base.Process();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Exit();
        }
    }

    public override void Exit()
    {
        GameManager.instance.startGameUI.gameObject.SetActive(false);

        base.Exit();
    }
}
