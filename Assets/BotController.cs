using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] float speed;
    private Vector3 destination;

    public bool IsDestination => Vector3.Distance(destination, transform.position) < 0.1f;

    public void SetDestination(Vector3 position)
    {
        destination = position;
        myNavMeshAgent.SetDestination(position);
    }



    IState<BotController> currentState;



    private void Update()
    {
        if (currentState != null) 
        {
            currentState.OnExecute(this);    
        }
    }


    public void ChangeState(IState<BotController> state)
    {
        if (currentState != null) 
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }



}
