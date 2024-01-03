using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Range(1, 10)]
    public int width, height;
    Vector3 origin;
    public GameObject brick;

    void Start()
    {
        for (int i = -4; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
               
                GameObject obj = Instantiate(brick, origin, transform.rotation, transform);
                origin = new Vector3(transform.position.x  + (i*1.25f), 0.5f, transform.position.z + (j*1.25f));
                obj.transform.position = origin;
            }
        }
    }
}
