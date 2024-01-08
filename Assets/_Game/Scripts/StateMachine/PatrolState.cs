using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<BotController>
{
    int targetBrick;

    void OnEnter(BotController t)
    {
        targetBrick = Random.Range(2, 6);

        Vector3 brickPoint = SeekBrickPoint(t.colorType);
    }

    private Vector3 SeekBrickPoint(ColorType colorType)
    {
        throw new System.NotImplementedException();
    }

    void OnExecute(BotController t)
    {

    }

    void OnExit(BotController t)
    {

    }
}
