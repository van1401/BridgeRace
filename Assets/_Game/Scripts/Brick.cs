using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    private void Start()
    {
        ChangeColor((ColorType)Random.Range(2, 5));
    }

}
