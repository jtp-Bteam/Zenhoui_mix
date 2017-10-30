using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllScoreScript : MonoBehaviour {

	private Text endlessScore;

	private void Start(){
		endlessScore = GameObject.Find("EndlessScore").GetComponent<Text>();
		endlessScore.text = "エンドレス     スコア:" + PlayerPrefs.GetInt("EndlessStageHighScore", 0);
	}

	public void StringArgFunction(String str){
		switch(str){
			case "Back":
				SceneManager.LoadScene("StartStage");
				break;
		}
	}
}
