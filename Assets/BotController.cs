using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] Transform destination;
    public int targetNumBrick;
    public int numberBrickCollected = 0;
    private int currentStage;

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
                    numberBrickCollected += 1;
                }
                else
                {
                    myNavMeshAgent.destination = GameObject.Find("FinishBox").transform.position;
                }
            }
        }
        if (other.CompareTag("Bridge"))
        {

        }
    }



    void SeekBrickPoint()
    {
        var target = GetClosestBrick(spawnController.Instance.BrickInStage1);
        if (target == null)
        {
            return;
        }
        if (currentStage == 0)
        {
            myNavMeshAgent.destination = target.position;
        }
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