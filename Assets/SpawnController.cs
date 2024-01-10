using System.Collections;
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
    public List<Vector3> rootPos = new List<Vector3>();
    public List<Vector3> botPos = new List<Vector3>();
    public List<Brick> brick = new List<Brick>();
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
        for (int i = -4; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                for (int k = 0; k < rootPos.Count; k++)
                {
                    Brick bricks = Instantiate(brickPrefab, rootPos[k], transform.rotation, transform);
                    Vector3 newpos = new Vector3(rootPos[k].x + (i * 1.25f), rootPos[k].y + 0.5f, rootPos[k].z + (j * 1.25f));
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
            var bot = Instantiate(botPrefab, botPos[i], transform.rotation); // sinh ra bot
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
