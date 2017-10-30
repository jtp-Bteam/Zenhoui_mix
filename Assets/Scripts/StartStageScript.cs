using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStageScript : MonoBehaviour {

	public void StringArgFunction(string str)
    {
		switch(str){
			case "SS":
				SceneManager.LoadScene("SelectStage");
				break;
			case "SE":
				SceneManager.LoadScene("SelectEquipment");
				break;
            case "AS":
                SceneManager.LoadScene("AllScore");
                break;
            case "BSS":
                SceneManager.LoadScene("BackSideSetting");
                break;
        }
    }
}
