using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ColorType
{
    Default,
    Black, 
    Red,
    Blue,
    Green,
    Yellow, 
    Orange,
    Brown,
}

public class Stage : MonoBehaviour
{
    public Transform[] brickPoints;
    
    public List<Vector3> emptyPoint = new List<Vector3>();




}
