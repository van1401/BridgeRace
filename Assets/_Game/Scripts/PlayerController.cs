using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = JoystickController.direct * speed + rb.velocity.y * Vector3.up;
           //rigid body velocity of player equal as joystickcontroller class direct, multiple with speed plus with rb velocty.y + vector3.up so they dont conflict with it own y axi
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
        }
    }




}
