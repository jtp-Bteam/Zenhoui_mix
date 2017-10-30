using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour {

    public Vector3[] SpawnPoint;
    private int time = 0;
    private int spawnInterval=100;
    private int index = 0;
    private int spawnCount = 0;
    private int spawnLimit = 20;
    private GameObject enemyObj;

	// Use this for initialization
	void Start () {

        enemyObj = (GameObject)Resources.Load("Prefabs/GyroEnemy");
    }
	
	// Update is called once per frame
	void Update () {

        if(time >= spawnInterval && spawnLimit > spawnCount)
        {
            GameObject enemy = Instantiate(enemyObj, SpawnPoint[index], Quaternion.identity);
            enemy.name = "Enemy";
            spawnCount++;

            if (index < SpawnPoint.Length - 1) index++;
            else index = 0;
            time = 0;
        }
        time++;

        if (spawnCount >= spawnLimit && GameObject.Find("Enemy") == null)
        {
            GameObject.Find("GyroStage").GetComponent<GyroStageScript>().GenerateBoss();
            Destroy(gameObject);
        }
    }
}
