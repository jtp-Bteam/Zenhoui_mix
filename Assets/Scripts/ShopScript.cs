using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    private Text currentMoney;
    private Text currentMaxHP;
    private Text currentMaxSpeed;
    private Text currentMaxBullet;
    private Text currentMaxCompanion;
    private Text hpPrice;
    private Text speedPrice;
    private Text bulletPrice;
    private Text companionPrice;

    private void Start()
    {
        currentMoney = GameObject.Find("CurrentMoney").GetComponent<Text>();
        currentMaxHP = GameObject.Find("CurrentMaxHP").GetComponent<Text>();
        currentMaxSpeed = GameObject.Find("CurrentMaxSpeed").GetComponent<Text>();
        currentMaxBullet = GameObject.Find("CurrentMaxBullet").GetComponent<Text>();
        currentMaxCompanion = GameObject.Find("CurrentMaxCompanion").GetComponent<Text>();
        hpPrice = GameObject.Find("HPPrice").GetComponent<Text>();
        speedPrice = GameObject.Find("SpeedPrice").GetComponent<Text>();
        bulletPrice = GameObject.Find("BulletPrice").GetComponent<Text>();
        companionPrice = GameObject.Find("CompanionPrice").GetComponent<Text>();

        //-----デバッグ用-----
        //PlayerPrefs.SetInt("CurrentMoney", 30);
        //PlayerPrefs.SetInt("CurrentMaxHP", 5);
        //PlayerPrefs.SetInt("CurrentMaxSpeed", 0);
        //PlayerPrefs.SetInt("CurrentMaxBullet", 0);
        //PlayerPrefs.SetInt("CurrentMaxCompanion", 0);
        //-----デバッグ用ここまで-----
    }

    private void Update()
    {
        currentMoney.text = PlayerPrefs.GetInt("CurrentMoney").ToString();
        currentMaxHP.text = PlayerPrefs.GetInt("CurrentMaxHP", 5).ToString();
        currentMaxSpeed.text = PlayerPrefs.GetInt("CurrentMaxSpeed").ToString();
        currentMaxBullet.text = PlayerPrefs.GetInt("CurrentMaxBullet").ToString();
        currentMaxCompanion.text = PlayerPrefs.GetInt("CurrentMaxCompanion").ToString();
        hpPrice.text = PlayerPrefs.GetInt("HPPrice", 5).ToString();
        speedPrice.text = PlayerPrefs.GetInt("SpeedPrice", 5).ToString();
        bulletPrice.text = PlayerPrefs.GetInt("BulletPrice", 30).ToString();
        companionPrice.text = PlayerPrefs.GetInt("CompanionPrice", 10).ToString();
    }

    public void StringArgFunction(string str)
    {
        switch (str)
        {
            case "Back":
                SceneManager.LoadScene("SelectEquipment");
                break;
            case "HP":
                if(PlayerPrefs.GetInt("CurrentMoney") >= PlayerPrefs.GetInt("HPPrice", 5))
                {
                    PlayerPrefs.SetInt("CurrentMoney", PlayerPrefs.GetInt("CurrentMoney") - PlayerPrefs.GetInt("HPPrice", 5));
                    PlayerPrefs.SetInt("CurrentMaxHP", PlayerPrefs.GetInt("CurrentMaxHP", 5) + 1);
                }
                break;
            case "Speed":
                if (PlayerPrefs.GetInt("CurrentMoney") >= PlayerPrefs.GetInt("SpeedPrice", 5))
                {
                    PlayerPrefs.SetInt("CurrentMoney", PlayerPrefs.GetInt("CurrentMoney") - PlayerPrefs.GetInt("SpeedPrice", 5));
                    PlayerPrefs.SetInt("CurrentMaxSpeed", PlayerPrefs.GetInt("CurrentMaxSpeed") + 1);
                }
                break;
            case "Bullet":
                if (PlayerPrefs.GetInt("CurrentMoney") >= PlayerPrefs.GetInt("BulletPrice", 30))
                {
                    PlayerPrefs.SetInt("CurrentMoney", PlayerPrefs.GetInt("CurrentMoney") - PlayerPrefs.GetInt("BulletPrice", 30));
                    PlayerPrefs.SetInt("CurrentMaxBullet", PlayerPrefs.GetInt("CurrentMaxBullet") + 1);
                }
                break;
            case "Companion":
                if (PlayerPrefs.GetInt("CurrentMoney") >= PlayerPrefs.GetInt("CompanionPrice", 10))
                {
                    PlayerPrefs.SetInt("CurrentMoney", PlayerPrefs.GetInt("CurrentMoney") - PlayerPrefs.GetInt("CompanionPrice", 10));
                    PlayerPrefs.SetInt("CurrentMaxCompanion", PlayerPrefs.GetInt("CurrentMaxCompanion") + 1);
                }
                break;
        }
    }
}
