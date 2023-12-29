using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody rb;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 nextPoint = JoystickController.direct * speed * Time.deltaTime + transform.position;
            transform.position = CheckGround(nextPoint);
            //rb.velocity = JoystickController.direct * speed + rb.velocity.y * Vector3.up;
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    rb.velocity = Vector3.zero;
        //}
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
