using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour {

    private void Start()
    {
        String preStage = PlayerPrefs.GetString("PreStage");
        int preTime = (int)PlayerPrefs.GetFloat("PreTime");
        int preScore = PlayerPrefs.GetInt("PreScore");

        if (preScore > PlayerPrefs.GetInt(preStage + "HighScore")) //ハイスコアを記録したとき
        {
            PlayerPrefs.SetInt(preStage + "HighScore", preScore);
        }
        if (preStage != "EndlessStage")
        {
            if(preTime < PlayerPrefs.GetFloat(preStage + "BestTime")) //ベストタイムを記録したとき
            {
                PlayerPrefs.SetInt(preStage + "BestTime", preTime);
            }
        }

        Text time = GameObject.Find("Time").GetComponent<Text>();
        time.text = "Time\n" + preTime;
        Text score = GameObject.Find("Score").GetComponent<Text>();
        score.text = "Score\n" + preScore;
        PlayerPrefs.SetInt("CurrentMoney", PlayerPrefs.GetInt("CurrentMoney") + preScore);
    }

    public void BoolArgFunction(bool b){
        if(PlayerPrefs.GetString("PreStage") == "EndlessStage") SceneManager.LoadScene("SelectEquipment");
        else SceneManager.LoadScene("SelectStage");
    }
}
