using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] float speed;




    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 nextPoint = JoystickController.direct * speed * Time.deltaTime + transform.position;
            if (CanMove(nextPoint))
            {
                transform.position = CheckGround(nextPoint);
            }
            if (JoystickController.direct != Vector3.zero)
            {
                skin.forward = JoystickController.direct;
            }
        }
    }
}
