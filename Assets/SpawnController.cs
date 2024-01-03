using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<Vector3> rootPos;
    [Range(1, 10)]
    public int width, height;
    public GameObject brick;

    void Start()
    {
        for (int i = -4; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                GameObject stage = Instantiate(brick, rootPos[0], transform.rotation, transform);
                GameObject stage1 = Instantiate(brick, rootPos[1], transform.rotation, transform);
                GameObject stage2 = Instantiate(brick, rootPos[2], transform.rotation, transform);

                Vector3 newpos = new Vector3(rootPos[0].x + (i * 1.25f), rootPos[0].y + 0.5f, rootPos[0].z + (j * 1.25f));
                Vector3 newpos1 = new Vector3(rootPos[1].x + (i * 1.25f), rootPos[1].y + 0.5f, rootPos[1].z + (j * 1.25f));
                Vector3 newpos2 = new Vector3(rootPos[2].x + (i * 1.25f), rootPos[2].y + 0.5f, rootPos[2].z + (j * 1.25f));

                stage.transform.position = newpos;
                stage1.transform.position = newpos1;
                stage2.transform.position = newpos2;
            }
        }
    }
}
