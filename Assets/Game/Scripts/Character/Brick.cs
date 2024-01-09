using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    private void Start()
    {
        ChangeColor((ColorType)Random.Range(3, 7));
        
    }

    private void OnDisable()
    {
        Invoke("SetActive", 3.5f);
    }

    void SetActive()
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
            ChangeColor((ColorType)Random.Range(3, 7));
        }   
    }
}
