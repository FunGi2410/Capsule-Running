using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float spawnTimeDistance;
    private float mySpawnTime;
    public GameObject Enemy;
    private UIManager myUI;

    private GameController myGameController;
    void Start()
    {
        mySpawnTime = 0;
        myGameController = FindObjectOfType<GameController>();
        myUI = FindObjectOfType<UIManager>();
    }

    private float count = 0f; // khi count = 0 thi load menu panel
    void Update()
    {
        // Nếu không nhấn gì và count = 0 thì luôn sẽ truyền cho hàm myUI.SetIsShow là true
        // để luôn show Start Panel
        if (Input.GetAxisRaw("Fire1") == 0 && count==0)
        {
            myUI.SetIsShow(true);
            return;
        }
        else
        {
            // Khi có nhấn chuột thì count công lên và luôn lớn hơn 0. Lệnh if trên
            // sẽ không hoạt động trong suốt quá trình chơi
            count++;
            myUI.SetIsShow(false);
        }
        if (myGameController.GetGameover())
        {
            mySpawnTime = 0f;
            return;
        }
        mySpawnTime -= Time.deltaTime;
        if (mySpawnTime <= 0)
        {
            MySpawnEnemy();
            spawnTimeDistance = Random.Range(1f, 2f);
            mySpawnTime = spawnTimeDistance;
        }
    }
    

    
    void MySpawnEnemy()
    {
        float randSpawnEnemy = Random.Range(1f, 10f);
        float randYPositionAbove = Random.Range(6.261537f, 7.93f);
        float randYPositionUnder = Random.Range(-7.79f, -6.332164f);
        float randYPositionSingle = Random.Range(2.9f, 4.41f);
        Vector2 spawnPositionAbove = new Vector2(transform.position.x, randYPositionAbove);
        Vector2 spawnPositionUnder = new Vector2(transform.position.x, randYPositionUnder);
        Vector2 spawnPositionSingle = new Vector2(transform.position.x, randYPositionSingle);

        if (Enemy && randSpawnEnemy > 5)
        {
            Instantiate(Enemy, spawnPositionAbove, Quaternion.identity);
            Instantiate(Enemy, spawnPositionUnder, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemy, spawnPositionSingle, Quaternion.identity);
        }
    }
}
