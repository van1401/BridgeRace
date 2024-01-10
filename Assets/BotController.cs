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
        SeekBrickPoint();
        targetNumBrick = Random.Range(10, 20);
        //myNavMeshAgent.SetDestination(destination);
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
        var brickCount = spawnController.Instance.brick.Count;

        for (int i = 0; i < brickCount; i++)
        {
            if (spawnController.Instance.brick[i].colorType == colorType)
            {
                myNavMeshAgent.destination = spawnController.Instance.brick[i].transform.position;
                break;
            }
        }
    }
    Transform GetClosestBrick(Transform[] brick)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in brick)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
