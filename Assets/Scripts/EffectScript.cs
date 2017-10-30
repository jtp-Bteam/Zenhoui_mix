using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        switch (gameObject.name) {
            case "ExplosionMobile(Clone)":
                Invoke("DestroyObject", 2);
                break;
            case "Spark(Clone)":
                Invoke("DestroyObject", 4);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
    
}
