using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageScript : AbstractStageScript
{

    float[,] obs_vertical_p_pos = new float[24, 2];
    float[,] obs_vertical_n_pos = new float[24, 2];
    float[,] obs_horizon_p_pos = new float[24, 2];
    float[,] obs_horizon_n_pos = new float[24, 2];
    float[,] obs_slan1_pos = new float[24, 2];
    float[,] obs_slan2_pos = new float[24, 2];
    float[,] obs_slan3_pos = new float[24, 2];
    float[,] obs_slan4_pos = new float[24, 2];
    int mode = 0;
    int wave = 1;
    int enemy_num;
    bool setup;
    bool once = false;


    // Use this for initialization
    void Start()
    {
        playerObj = (GameObject)Resources.Load("Prefabs/Player");
        enemyObj = (GameObject)Resources.Load("Prefabs/Enemy");
        middlebossObj = (GameObject)Resources.Load("Prefabs/MiddleBoss");
        bossObj = null;
        obstacleObj1 = (GameObject)Resources.Load("Prefabs/Pillar");
        speedUpObj = (GameObject)Resources.Load("Prefabs/ItemSpeedUp");
        speedDownObj = (GameObject)Resources.Load("Prefabs/ItemSpeedDown");
        companionObj = (GameObject)Resources.Load("Prefabs/ItemCompanion");
        threeWayObj = (GameObject)Resources.Load("Prefabs/ItemThreeWay");

        obs_wave_time = 0;
        time = 0;

        GameObject player = Instantiate(playerObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        player.name = "Player";

    }

    // Update is called once per frame
    void Update(){
        if (GameObject.Find("Player") == null) Invoke("Clear", 3f);
        if(wave == 1 && setup == false){
            enemy_num = 10;
            for(int i = 0; i < enemy_num; i++){
                GenerateEnemy();
            }
            setup = true;
        }else if(wave == 1 && setup == true && once == false){
            InvokeRepeating("GenerateItem", 3f, 5f);
            once = true;
        }else if(wave == 1 && once == true && GameObject.Find("Enemy") == null){
            wave++;
            setup = false;
            once = false;
        }

        if (wave == 2 && setup == false) {
            enemy_num = 15;
            for (int i = 0; i < enemy_num; i++) {
                GenerateEnemy();
            }
            setup = true;
        } else if (wave == 2 && setup == true && once == false) {
            InvokeRepeating("SetRandomObstacle", 0f, 10f);
            once = true;
        } else if (wave == 2 && once == true && GameObject.Find("Enemy") == null){
            wave++;
            setup = false;
            once = false;
        }

        if (wave == 3 && setup == false) {
            enemy_num = 5;
            for (int i = 0; i < enemy_num; i++) {
                GenerateEnemy();
            }
            setup = true;
        }else if(wave == 3 && setup == true && once == false){
            Invoke("GenerateMiddleBossEnemy", 10f);
            once = true;
        }else if(wave == 3 && once == true && GameObject.Find("Enemy") == null){
            wave++;
            setup = false;
            once = false;
        }

        if(wave == 4 && setup == false){
            enemy_num = 2;
            for(int i = 0; i < enemy_num; i++){
                GenerateMiddleBossEnemy();
            }
            setup = true;
        }else if(wave == 4 && setup == true && once == false){
            Invoke("GenerateBossEnemy", 15f);
            once = true;
        }else if(wave == 4 && once == true && GameObject.Find("Enemy") == null){
            Invoke("Clear", 3f);
        }

    }

    private void FixedUpdate()
    {
        CountTime();
    }

    bool CanCreateItem(){
        if(Random.Range(1, 101) % 4 == 0){
            return true;
        }
        else{
            return false;
        }
    }

    public override void GenerateItem(){
        if (CanCreateItem()){
            int num = Random.Range(1, 41) % 4;
            switch (num){
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

    public float[,] GetRandomObsPos(){

        int num = 10 + Random.Range(1, 11);
        float[,] positions = new float[num, 2];
        for (int i = 0; i < num; i++)
        {
            positions[i, 0] = -20 + Random.value * 40;
            positions[i, 1] = -20 + Random.value * 40;
        }

        return positions;
    }

    public override void SetObstacle(float[,] pos)
    {
        int i = 0;
        for (i = 0; i < pos.GetLength(0); i++){
            GameObject obstacle = Instantiate(obstacleObj1, new Vector3(pos[i, 0], -(obstacleObj1.transform.localScale.y), pos[i, 1]), Quaternion.identity) as GameObject;
            obstacle.tag = "Obstacle";
        }
    }

    public void SetRandomObstacle(){
        SetObstacle(GetRandomObsPos());
    }

    public override void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
        enemy.name = "Enemy";
    }

    public void GenerateMiddleBossEnemy(){
        GameObject middleboss = Instantiate(middlebossObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
        middleboss.name = "Enemy"; 
    }

    public void GenerateBossEmeny(){
        GameObject boss = Instantiate(enemyObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
        boss.name = "Enemy";
    }
}
