using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotController : Character
{
    [SerializeField] NavMeshAgent myNavMeshAgent;
    [SerializeField] Vector3 destination;
    int targetNumBrick;




    public void Start()
    {
  
        //CollectingBrick();
        targetNumBrick = Random.Range(10, 20);
        myNavMeshAgent.SetDestination(destination);
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

    void CollectingBrick()
    {
        if (gameObject.GetComponent<Brick>().transform.position == null)
        {
            return;
        }
        Vector3 nextPos = gameObject.GetComponent<Brick>().transform.position;
        myNavMeshAgent.destination = nextPos;

    }



    public GameObject FindClosestBrick(Transform Container)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Brick");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
