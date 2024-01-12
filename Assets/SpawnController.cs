﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LTAUnityBase.Base.DesignPattern;

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

public class SpawnController : MonoBehaviour
{
    public List<Vector3> botPos = new List<Vector3>();
    public List<Brick> brick = new List<Brick>();
    public List<Transform> Stage = new List<Transform>();
    [Range(1, 10)]
    public int width, height;
    public Brick brickPrefab;
    public BotController botPrefab;
    public static SpawnController Instance;




    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        SpawnBrick();
        SpawnBot();
    }


    void SpawnBrick()
    {
        for (int i = -5; i < width; i++)
        {
            for (int j = -5; j < height; j++)
            {
                for (int k = 0; k < Stage.Count; k++)
                {
                    Brick bricks = Instantiate(brickPrefab, Stage[k].transform.position, transform.rotation, transform);
                    Vector3 newpos = new Vector3(Stage[k].transform.position.x + (i * 2.00f), Stage[k].transform.position.y + 0.5f, Stage[k].transform.position.z + (j * 2.00f));
                    bricks.transform.position = newpos;
                    brick.Add(bricks);
                }
            }
        }
    }

    void SpawnBot()
    {
        List<int> getColor = new List<int>(); //Tạo List get màu 
        int randomNumber = Random.Range(4, 7); // tạo số random từ 2 ~ 6
        for (int i = 0; i < botPos.Count; i++) // Vòng lặp for dùng để đếm bot
        {
            var bot = Instantiate(botPrefab, botPos[i], transform.rotation, transform);
            while (getColor.Contains(randomNumber)) // get màu chứa số ngẫu nhiên từ 2 ~ 6
            {
                randomNumber = Random.Range(4, 7); // random số để chọn màu
            }
            getColor.Add(randomNumber); //sau khi bỏ số ra thì chọn 1 số mới
            bot.ChangeColor((ColorType)randomNumber); // đổi màu bot bằng số 
        }
    }

}

public class spawnController : SingletonMonoBehaviour<SpawnController>
{

}
