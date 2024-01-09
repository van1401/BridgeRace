using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTF;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTF.position + offset, Time.deltaTime * 5f);
    }
}
