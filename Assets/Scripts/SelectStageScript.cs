using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageScript : MonoBehaviour {

    public void StringArgFunction(string name)
    {
        if(name == null) SceneManager.LoadScene("StartStage");
        SceneManager.LoadScene(name);
    }
}
