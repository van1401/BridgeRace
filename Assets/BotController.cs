using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] Transform destination;
    public int targetNumBrick;
    public int numberBrickCollected = 0;



    public void Start()
    {
        targetNumBrick = Random.Range(10, 20);
    }
    private void Update()
    {
        if (myNavMeshAgent.remainingDistance <= 0.1f)
        {
            SeekBrickPoint();
        }
        if(targetNumBrick >= Random.Range(10,20))
        {
            Transform target = GameObject.Find("FinishBox").transform;
            myNavMeshAgent.SetDestination(target.position);
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
                if (numberBrickCollected <= targetNumBrick)
                {
                    SeekBrickPoint();
                }
                else
                {
                    targetNumBrick = Random.Range(10, 20);
                    myNavMeshAgent.destination = destination.position;
                }
            }
        }
    }

    void SeekTarget()
    {
        if (SpawnController.Instance.Stage[0] == true && targetNumBrick >=0)
        {
            SeekBrickPoint();
        }
        else if (SpawnController.Instance.Stage[0] != false && targetNumBrick >=0)
        {

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