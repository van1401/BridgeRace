using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    private Vector3 destination;

    public bool IsDestination => Vector3.Distance(destination, transform.position) < 0.1f;




    public void Start()
    {
        myNavMeshAgent.SetDestination(destination);
    }

    public void SetDestination(Vector3 position)
    {
        destination = position;
        myNavMeshAgent.SetDestination(position);
    }    




    private void OnTriggerEnter(Collider other)
    {
        
    }
}
