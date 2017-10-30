//これは戦闘時カメラのために作ったスクリプトなので、それ以外のシーンのカメラにくっつけても動きません

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCameraScript : MonoBehaviour
{

    GameObject player;
    PlayerScript ps;

    GameObject stage;
    AbstractStageScript ass;

    Text hp;
    Text time;
    Text score;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") && player == null) player = GameObject.Find("Player");
        FollowPlayer();
        DisplayHUD();
    }

    private void FollowPlayer()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 20, player.transform.position.z - 4);
        }
    }

    private void DisplayHUD()
    {
        if (stage == null) stage = GameObject.Find(SceneManager.GetActiveScene().name);
        if (stage != null && ass == null) ass = stage.GetComponent<AbstractStageScript>();
        
        if (player == null && GameObject.Find("Player")) player = GameObject.Find("Player");
        if (ps == null && GameObject.Find("Player")) ps = player.GetComponent<PlayerScript>();
        //switch (text.name)
        //{
        //    case "HP":
        //        if (GameObject.Find("Player") == false) text.text = "HP:0";
        //        else text.text = "HP:" + ps.GetHP();
        //        break;
        //    case "Time":
        //        text.text = "Time:" + (int)ass.GetTime();
        //        break;
        //    case "Score":
        //        text.text = "SCORE:" + ass.GetScore();
        //        break;
        //}

        if (hp == null) hp = GameObject.Find("HP").GetComponent<Text>();
        if (time == null) time = GameObject.Find("Time").GetComponent<Text>();
        if (score == null) score = GameObject.Find("Score").GetComponent<Text>();

        if (GameObject.Find("Player") == false)
        {
            hp.text = "HP:0";
        }
        else
        {
            hp.text = "HP:" + ps.GetHP();
        }
        time.text = "Time:" + (int)ass.GetTime();
        score.text = "SCORE:" + ass.GetScore();
    }
}
