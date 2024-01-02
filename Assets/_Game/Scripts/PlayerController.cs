using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : ColorObject
{

    [SerializeField] float speed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody rb;

    public Stage stage;


    private List<PlayerBrick> playerBricks = new List<PlayerBrick> ();
    [SerializeField] PlayerBrick playerBrickPrefab;
    [SerializeField] Transform brickHolder;
    [SerializeField] Transform skin;



    private void Start()
    {
        ChangeColor(ColorType.Blue);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 nextPoint = JoystickController.direct * speed * Time.deltaTime + transform.position;
            transform.position = CheckGround(nextPoint);
            skin.forward = JoystickController.direct;
        }
    }

    void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.position = Vector3.up * 0.25f * playerBricks.Count;
        playerBricks.Add(playerBrick);
    }

    void RemoveBrick()
    {
        if(playerBricks.Count > 0) 
        {
            PlayerBrick playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }

    void ClearBrick()
    {
        for(int i = 0; i< playerBricks.Count; i++)
        {
            Destroy(playerBricks[i]);
        }
        playerBricks.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();
            if(brick.colorType == colorType)
            {
                Destroy(brick.gameObject);
                AddBrick();
            }
        }
    }




    public Vector3 CheckGround (Vector3 nextPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, groundLayer))
        {
           return hit.point + Vector3.up * 1.1f; 
        }
        return transform.position;
    }
}
