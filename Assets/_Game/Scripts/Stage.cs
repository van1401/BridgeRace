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

    [SerializeField] Brick brickPrefab;

    internal Vector3 SeekBrickPoint (ColorType colorType)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        for(int i = 0; i < brickPoints.Length; i++)
        {
            emptyPoint.Add(brickPoints[i].position);
        }
    }

    public void InitColor(ColorType colorType, int amount)
    {
        for (int i = 0;i <amount;i++)
        {
            NewBrick(colorType);
        }
    }

    private void NewBrick(ColorType colorType)
    {
        if (emptyPoint.Count > 0)
        {
            int random = Random.Range(0, emptyPoint.Count);
            Brick brick = Instantiate(brickPrefab, emptyPoint[random], Quaternion.identity);
            //brick.stage = this;
            brick.ChangeColor(colorType);
            emptyPoint.RemoveAt(random);
        }


    }
}
