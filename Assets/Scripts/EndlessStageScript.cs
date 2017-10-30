using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStageScript : AbstractStageScript {

    // Use this for initialization
    void Start()
    {
        playerObj = (GameObject)Resources.Load("Prefabs/Player");
        enemyObj = (GameObject)Resources.Load("Prefabs/Enemy");
        speedUpObj = (GameObject)Resources.Load("Prefabs/ItemSpeedUp");
        speedDownObj = (GameObject)Resources.Load("Prefabs/ItemSpeedDown");
        companionObj = (GameObject)Resources.Load("Prefabs/ItemCompanion");
        threeWayObj = (GameObject)Resources.Load("Prefabs/ItemThreeWay");

        time = 0;

        GameObject player = Instantiate(playerObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        player.name = "Player";

        int i;
        for (i = 0; i < 5; i++)
        {
            GenerateEnemy();
        }
        InvokeRepeating("GenerateEnemy", 3f, 1f);
    }

    private void Update()
    {
        if (GameObject.Find("Player") == null) Invoke("Clear", 3f);
    }

    void FixedUpdate()
    {
        if (Random.value < 0.002) GenerateItem();
        
        CountTime();
    }

    public override void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity) as GameObject;
        enemy.name = "Enemy";
    }

    public override void GenerateItem()
    {
        float rand = Random.value;
        if (rand < (1.0 / 4.0))
        {
            Instantiate(speedUpObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity);
        }
        else if (rand < (2.0 / 4.0))
        {
            Instantiate(speedDownObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity);
        }
        else if(rand < (3.0 / 4.0))
        {
            Instantiate(companionObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity);
        }
        else
        {
            Instantiate(threeWayObj, new Vector3(-20 + Random.value * 40, 0, -20 + Random.value * 40), Quaternion.identity);
        }
    }
}
