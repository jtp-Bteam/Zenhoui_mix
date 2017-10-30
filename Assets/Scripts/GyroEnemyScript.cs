using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GyroEnemyScript : SmartEnemyScript {

    AbstractStageScript ass;

    public override void Start()
    {
        base.Start();
        ass = GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<AbstractStageScript>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.tag == "CrushZone")
        {
            Debug.Log("c");
            hp = 0;
            Instantiate(explodObj, gameObject.transform.position, Quaternion.identity);
            ass.AddScore();
            Destroy(gameObject);
        }
    }
}
