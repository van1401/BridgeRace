using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] LayerMask groundLayer;
    public LayerMask stepLayer;
    [SerializeField] Rigidbody rb;

    protected List<PlayerBrick> playerBricks = new List<PlayerBrick>();
    public PlayerBrick playerBrickPrefab;
    public Transform brickHolder;
    public Transform skin;


    private void Start()
    {

    }

    private void Update()
    {

    }

    protected void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.localPosition = Vector3.up * 0.25f * playerBricks.Count + new Vector3(0, 0, -0.8f);
        playerBricks.Add(playerBrick);
    }

    public void RemoveBrick()
    {
        if (playerBricks.Count > 0)
        {
            PlayerBrick playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
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

    public bool CanMove(Vector3 nextPoint)
    {
        bool canMove = true;

        RaycastHit hit;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, stepLayer))
        {
            Step step = hit.collider.GetComponent<Step>();
            if (step.colorType != colorType && playerBricks.Count > 0)
            {
                step.ChangeColor(colorType);
                RemoveBrick();
            }
            if (step.colorType != colorType && playerBricks.Count == 0 && skin.forward.z > 0)
            {
                canMove = false;
            }
        }
        return canMove;
    }


    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, groundLayer))
        {
            return hit.point + Vector3.up * 1.1f;
        }
        return transform.position;
    }
}
