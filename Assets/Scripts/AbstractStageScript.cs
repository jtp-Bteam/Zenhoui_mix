//このスクリプトは戦闘用ステージの抽象クラスであり、全てのステージ（たとえばスタート画面）に適用できるものではありません

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AbstractStageScript : MonoBehaviour {

    protected float time;
    protected float obs_wave_time;
    protected float enemy_wave_time;

    //-----ここから必要に応じてプレハブにぶち込む用-----
    
    protected GameObject playerObj;
    protected GameObject enemyObj;
    protected GameObject middlebossObj;
    protected GameObject bossObj;
    protected GameObject obstacleObj1;
    protected GameObject obstacleObj2;
    protected GameObject speedUpObj;
    protected GameObject speedDownObj;
    protected GameObject companionObj;
    protected GameObject threeWayObj;
    protected GameObject heartObj;
    //-----ここまで必要に応じてプレハブにぶち込む用-----

    int score = 0;

    public virtual void GenerateEnemy()
    {
    }

    public virtual void GenerateObstacle()
    {
    }

    public virtual void SetObstacle(float[,] pos)
    {

    }

    public virtual void GenerateItem()
    {
    }

    public void CountTime()
    {
        if(SceneManager.GetActiveScene().name == "EndlessStage"){
            if(GameObject.Find("Player") != false) time += Time.deltaTime;
        }
        else{
            if(time > 0 && GameObject.Find("Player") != false) time -= Time.deltaTime;
        }
    }

    public float GetTime()
    {
        return time;
    }
    
    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score++;
    }

    public virtual void Clear()
    {
        PlayerPrefs.SetString("PreStage", SceneManager.GetActiveScene().name); //リザルト画面に移動した際に前のステージ名を覚えておくため
        PlayerPrefs.SetFloat("PreTime", GetTime()); //同上
        PlayerPrefs.SetInt("PreScore", GetScore()); //同上

        if(GameObject.Find("Player") != false) //勝ち負け判定
        {
            PlayerPrefs.SetInt("PreJudge", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PreJudge", 0);
        }

        SceneManager.LoadScene("Result");
    }
}
