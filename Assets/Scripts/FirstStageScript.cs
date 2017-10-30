using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageScript : AbstractStageScript
{

    float[,] obstaclePotisions;
    int wave = 1;


    // Use this for initialization
    void Start() {
        playerObj = (GameObject)Resources.Load("Prefabs/Player");
        enemyObj = (GameObject)Resources.Load("Prefabs/Enemy");
        obstacleObj1 = (GameObject)Resources.Load("Prefabs/Pillar");
        obstacleObj2 = null;
        speedUpObj = (GameObject)Resources.Load("Prefabs/ItemSpeedUp");
        speedDownObj = (GameObject)Resources.Load("Prefabs/ItemSpeedDown");
        companionObj = (GameObject)Resources.Load("Prefabs/ItemCompanion");
        threeWayObj = (GameObject)Resources.Load("Prefabs/ItemThreeWay");

        obstaclePotisions = new float[,] { { -1, 6 }, { 2, -2 }, { 13, 3 }, { -4, 14 }, { 5, 5 } };

        obs_wave_time = 0;
        time = 0;

        GameObject player = Instantiate(playerObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        player.name = "Player";

        int i;
        for (i = 0; i < 5; i++){
            GameObject enemy = Instantiate(enemyObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
            enemy.name = "Enemy";
        }
        SetObstacle(obstaclePotisions);
        InvokeRepeating("GenerateItem", 3f, 10f);

    }

    // Update is called once per frame
    void Update() {
        obs_wave_time += Time.deltaTime;
        enemy_wave_time += Time.deltaTime;

        if (GameObject.Find("Player") == null) Invoke("Clear", 3f);

        if (obs_wave_time >= 10) {
            obs_wave_time = 0;
            float[,] position = GetRandomObsPos();
            SetObstacle(position);
        }

        if (wave <= 3 && GameObject.Find("Enemy") == null) {
            int enemy_num = wave * 3;
            for (int i = 0; i < enemy_num; i++) {
                GenerateEnemy();
            }
            wave++;
        }else if(wave == 4 && GameObject.Find("Enemy") == null){
            Invoke("Clear", 3f);
        }
    }

    bool CanCreateItem()
    {
        if (Random.Range(1, 101) % 4 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void GenerateItem()
    {
        if (CanCreateItem())
        {
            int num = Random.Range(1, 41) % 4;
            switch (num)
            {
                case 0:
                    GameObject item1 = Instantiate(speedUpObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
                    break;

                case 1:
                    GameObject item2 = Instantiate(speedDownObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
                    break;

                case 2:
                    GameObject item3 = Instantiate(companionObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
                    break;

                case 3:
                    GameObject item4 = Instantiate(threeWayObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
                    break;
            }
        }
    }

    private float[,] GetRandomObsPos(){

        int num = 40 + Random.Range(1, 21);
        float[,] positions = new float[num, 2];
        for(int i = 0; i < num; i++) {
            positions[i, 0] = -20 + Random.value * 40;
            positions[i, 1] = -20 + Random.value * 40;
        }

        return positions;
    }

    public override void SetObstacle(float[,] pos){
        int i = 0;
        for (i = 0; i < pos.GetLength(0); i++){
            GameObject obstacle = Instantiate(obstacleObj1, new Vector3(pos[i, 0], -(obstacleObj1.transform.localScale.y), pos[i, 1]), Quaternion.identity) as GameObject;
            obstacle.tag = "Obstacle";
        }
    }

    public override void GenerateObstacle(){
        GameObject obstacle = Instantiate(obstacleObj1, new Vector3(-20 + Random.value * 40, -(obstacleObj1.transform.localScale.y), -20 + Random.value * 40), Quaternion.identity) as GameObject;
        obstacle.tag = "Obstacle";
    }

    public override void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
        enemy.name = "Enemy";
    }
}
