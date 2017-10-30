using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionScript : MonoBehaviour {

    GameObject player;
    GameObject explodObj;
    int num;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        explodObj = (GameObject)Resources.Load("Prefabs/ExplosionMobile");
	}

    public void Create(int num)
    {
        this.num = num;
    }
	
	// Update is called once per frame
	void Update () {
        switch (num)
        {
            case 0:
                transform.position = player.transform.position - (player.transform.right * 2);
                break;
            case 1:
                transform.position = player.transform.position + (player.transform.right * 2);
                break;
            case 2:
                transform.position = player.transform.position - (player.transform.right * 4);
                break;
            case 3:
                transform.position = player.transform.position + (player.transform.right * 4);
                break;
        }
        transform.rotation = player.transform.rotation;
	}

    private void FixedUpdate()
    {
        if (GameObject.Find("Player") == null)
        {
            Debug.Log("わおわおわーお！");
            Instantiate(explodObj, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
