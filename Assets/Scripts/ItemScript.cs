using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    GameObject player;
    PlayerScript ps;

	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player");
        //ps = player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Player")) player = GameObject.Find("Player");
        if(GameObject.Find("Player")) ps = player.GetComponent<PlayerScript>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            switch (gameObject.name)
            {
                case "ItemSpeedUp(Clone)":
                    ps.IncreaseSpeed();
                    break;
                case "ItemSpeedDown(Clone)":
                    ps.DecreaseSpeed();
                    break;
                case "ItemCompanion(Clone)":
                    ps.AddCompanion();
                    break;
                case "ItemThreeWay(Clone)":
                    ps.ApplyThreeWay();
                    break;
                case "ItemHeart()":
                    ps.IncreaseHP();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
