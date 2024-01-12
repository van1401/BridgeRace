using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] Vector3 destination;
    public int targetNumBrick;




    public void Start()
    {
        targetNumBrick = Random.Range(10, 20);
        //myNavMeshAgent.SetDestination(destination);
    }
    private void Update()
    {
        if (myNavMeshAgent.remainingDistance <= 0.1f)
        {
            SeekBrickPoint();
        }
        if(targetNumBrick == Random.Range(10,20))
        {

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.gameObject.SetActive(false);
                AddBrick();
            }
        }
    }

    void SeekBrickPoint()
    {
        var target = GetClosestBrick(spawnController.Instance.brick);
        if (target == null)
        {
            return;
        }
        myNavMeshAgent.destination = target.position;
    }

    Transform GetClosestBrick(List<Brick> brick)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        for (int i = 0; i < brick.Count; i++)
        {
            Brick potentialTarget = brick[i];
            if (potentialTarget.colorType != colorType)
            {
                continue;
            }
            if (!potentialTarget.gameObject.activeSelf)
            {
                continue;
            }
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }
}