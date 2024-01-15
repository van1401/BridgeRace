using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LTAUnityBase.Base.DesignPattern;
using Unity.VisualScripting;

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
    public List<Transform> Stage = new List<Transform>();
    public List<Brick> BrickInStage1 = new List<Brick>();
    public List<Brick> BrickInStage2 = new List<Brick>();
    public List<Brick> BrickInStage3 = new List<Brick>();


    [Range(1, 10)]
    public int width, height;
    public Brick brickPrefab;
    public BotController botPrefab;
    public static SpawnController Instance;
    private Brick bricks;




    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        SpawnBot();
        SpawnBrick();
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

    void SpawnBrick()
    {
        //for (int k = 0; k < Stage.Count; k++)
        //{

        //}
        for (int i = -5; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                bricks = Instantiate(brickPrefab, Stage[0].transform.position, transform.rotation, transform);
                Vector3 newpos = new Vector3(Stage[0].transform.position.x + (i * 2.00f), Stage[0].transform.position.y + 0.5f, Stage[0].transform.position.z + (j * 2.00f));
                bricks.transform.position = newpos;
                BrickInStage1.Add(bricks);
            }
        }
        for (int i = -5; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                bricks = Instantiate(brickPrefab, Stage[1].transform.position, transform.rotation, transform);
                Vector3 newpos = new Vector3(Stage[1].transform.position.x + (i * 2.00f), Stage[1].transform.position.y + 0.5f, Stage[1].transform.position.z + (j * 2.00f));
                bricks.transform.position = newpos;
                BrickInStage2.Add(bricks);
            }
        }
        for (int i = -5; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                bricks = Instantiate(brickPrefab, Stage[2].transform.position, transform.rotation, transform);
                Vector3 newpos = new Vector3(Stage[2].transform.position.x + (i * 2.00f), Stage[2].transform.position.y + 0.5f, Stage[2].transform.position.z + (j * 2.00f));
                bricks.transform.position = newpos;
                BrickInStage3.Add(bricks);
            }
        }
    }

}

public class spawnController : SingletonMonoBehaviour<SpawnController>
{

}
