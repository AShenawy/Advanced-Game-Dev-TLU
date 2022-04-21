using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameRunning State", menuName = "State/Game Running")]
public class GameRunningState : BaseState
{
    public override void Enter()
    {
        base.Enter();

        // Make the game move at normal speeed
        Time.timeScale = 1;
    }

    public override void Process()
    {
        base.Process();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
