using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] Vector3 destination;


    public void Start()
    {
        ChangeColor((ColorType)Random.Range(2, 6));
        myNavMeshAgent.SetDestination(destination);
    }

    //IState<BotController> currentState;



    private void Update()
    {
        //if (currentState != null) 
        //{
        //    currentState.OnExecute(this);    
        //}
    }


    //public void ChangeState(IState<BotController> state)
    //{
    //    if (currentState != null) 
    //    {
    //        currentState.OnExit(this);
    //    }

    //    currentState = state;

    //    if(currentState != null)
    //    {
    //        currentState.OnEnter(this);
    //    }
    //}

}
