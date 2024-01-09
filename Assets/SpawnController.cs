using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    public List<Vector3> rootPos;
    public List<Vector3> botPos;
    [Range(1, 10)]
    public int width, height;
    public GameObject brickPrefab;
    public BotController botPrefab;



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
                    GameObject stage = Instantiate(brickPrefab, rootPos[k], transform.rotation, transform);
                    Vector3 newpos = new Vector3(rootPos[k].x + (i * 1.25f), rootPos[k].y + 0.5f, rootPos[k].z + (j * 1.25f));
                    stage.transform.position = newpos;
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
