using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectEquipmentScript : MonoBehaviour {

    private Text currentMoney;
    private Text currentHP;
    private Text currentSpeed;
    private Text currentBullet;
    private Text currentCompanion;

    private Text currentMaxHP;
    private Text currentMaxSpeed;
    private Text currentMaxBullet;
    private Text currentMaxCompanion;

    private void Start()
    {
        currentMoney = GameObject.Find("CurrentMoney").GetComponent<Text>();
        currentHP = GameObject.Find("CurrentHP").GetComponent<Text>();
        currentSpeed = GameObject.Find("CurrentSpeed").GetComponent<Text>();
        currentBullet = GameObject.Find("CurrentBullet").GetComponent<Text>();
        currentCompanion = GameObject.Find("CurrentCompanion").GetComponent<Text>();

        currentMaxHP = GameObject.Find("CurrentMaxHP").GetComponent<Text>();
        currentMaxSpeed = GameObject.Find("CurrentMaxSpeed").GetComponent<Text>();
        currentMaxBullet = GameObject.Find("CurrentMaxBullet").GetComponent<Text>();
        currentMaxCompanion = GameObject.Find("CurrentMaxCompanion").GetComponent<Text>();

        //-----デバッグ用-----
        // PlayerPrefs.SetInt("CurrentHP", 5);
        // PlayerPrefs.SetInt("CurrentSpeed", 0);
        // PlayerPrefs.SetInt("CurrentBullet", 0);
        // PlayerPrefs.SetInt("CurrentCompanion", 0);
        //-----デバッグ用ここまで-----

        currentMaxHP.text = PlayerPrefs.GetInt("CurrentMaxHP", 5).ToString();
        currentMaxSpeed.text = PlayerPrefs.GetInt("CurrentMaxSpeed").ToString();
        currentMaxBullet.text = PlayerPrefs.GetInt("CurrentMaxBullet").ToString();
        currentMaxCompanion.text = PlayerPrefs.GetInt("CurrentMaxCompanion").ToString();
    }

    private void Update()
    {
        currentMoney.text = PlayerPrefs.GetInt("CurrentMoney").ToString();
        currentHP.text = PlayerPrefs.GetInt("CurrentHP").ToString();
        currentSpeed.text = PlayerPrefs.GetInt("CurrentSpeed").ToString();
        currentBullet.text = PlayerPrefs.GetInt("CurrentBullet").ToString();
        currentCompanion.text = PlayerPrefs.GetInt("CurrentCompanion").ToString();

        if (PlayerPrefs.GetInt("CurrentHP") > PlayerPrefs.GetInt("CurrentMaxHP", 5)) PlayerPrefs.SetInt("CurrentHP", PlayerPrefs.GetInt("CurrentMaxHP", 5));
        if (PlayerPrefs.GetInt("CurrentSpeed") > PlayerPrefs.GetInt("CurrentMaxSpeed")) PlayerPrefs.SetInt("CurrentSpeed", PlayerPrefs.GetInt("CurrentMaxSpeed"));
        if (PlayerPrefs.GetInt("CurrentBullet") > PlayerPrefs.GetInt("CurrentMaxBullet")) PlayerPrefs.SetInt("CurrentBullet", PlayerPrefs.GetInt("CurrentMaxBullet"));
        if (PlayerPrefs.GetInt("CurrentCompanion") > PlayerPrefs.GetInt("CurrentMaxCompanion")) PlayerPrefs.SetInt("CurrentCompanion", PlayerPrefs.GetInt("CurrentMaxCompanion"));
    }

    public void StringArgFunction(string str)
    {
		switch(str){
			case "Back":
				SceneManager.LoadScene("StartStage");
				break;
            case "Go":
                SceneManager.LoadScene("EndlessStage");
                break;
            case "Shop":
                SceneManager.LoadScene("Shop");
                break;
            case "IncreaseHP":
                if (PlayerPrefs.GetInt("CurrentHP") < 10) PlayerPrefs.SetInt("CurrentHP", PlayerPrefs.GetInt("CurrentHP") + 1);
                break;
            case "DecreaseHP":
                if (PlayerPrefs.GetInt("CurrentHP") > 5) PlayerPrefs.SetInt("CurrentHP", PlayerPrefs.GetInt("CurrentHP") - 1);
                break;
            case "IncreaseSpeed":
                if(PlayerPrefs.GetInt("CurrentSpeed") < 3) PlayerPrefs.SetInt("CurrentSpeed", PlayerPrefs.GetInt("CurrentSpeed") + 1);
                break;
            case "DecreaseSpeed":
                if(PlayerPrefs.GetInt("CurrentSpeed") > 0)PlayerPrefs.SetInt("CurrentSpeed", PlayerPrefs.GetInt("CurrentSpeed") - 1);
                break;
            case "IncreaseBullet":
                if(PlayerPrefs.GetInt("CurrentBullet") < 3) PlayerPrefs.SetInt("CurrentBullet", PlayerPrefs.GetInt("CurrentBullet") + 1);
                break;
            case "DecreaseBullet":
                if(PlayerPrefs.GetInt("CurrentBullet") > 0) PlayerPrefs.SetInt("CurrentBullet", PlayerPrefs.GetInt("CurrentBullet") - 1);
                break;
            case "IncreaseCompanion":
                if(PlayerPrefs.GetInt("CurrentCompanion") < 5) PlayerPrefs.SetInt("CurrentCompanion", PlayerPrefs.GetInt("CurrentCompanion") + 1);
                break;
            case "DecreaseCompanion":
                if(PlayerPrefs.GetInt("CurrentCompanion") > 0) PlayerPrefs.SetInt("CurrentCompanion", PlayerPrefs.GetInt("CurrentCompanion") - 1);
                break;
        }
    }
}
