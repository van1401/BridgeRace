using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    private void Start()
    {
        ChangeColor((ColorType)Random.Range(2, 5));
        Invoke("SetActive", 5.0f);

    }
 

    void SetActive()
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
            ChangeColor((ColorType)Random.Range(2, 5));
        }   
    }
}
