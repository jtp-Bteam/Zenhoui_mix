using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackSideSettingScript : MonoBehaviour {

	public Text text;

    void Start()
    {
        text = GameObject.Find("Description").GetComponent<Text>();
    }

    void Update(){
    }

	public void StringArgFunction(string str){
		switch(str){
			case "Back":
				SceneManager.LoadScene("StartStage");
				break;
            case "Player":
                Debug.Log(text.text);
                text.text = (Resources.Load("PlayerDescription") as TextAsset).text;
                break;
		}
	}
}
