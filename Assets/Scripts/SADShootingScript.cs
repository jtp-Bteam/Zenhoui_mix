using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SADShootingScript : AbstractShootingScript {

	// Use this for initialization
	void Start () {

        bullet = (GameObject)Resources.Load("Prefabs/EnemyBullet");
        if (gameObject.name == "Enemy")
        {
            InvokeRepeating("Shoot", Random.value, 0.5f);
            speed = 1000 * Time.deltaTime;
        }
    }

    public override void Shoot()
    {
        // 弾丸の複製
        GameObject bullets = Instantiate(bullet) as GameObject;
        bullets.transform.localScale = new Vector3(2, 2, 2);

        Vector3 force = gameObject.transform.forward * speed;
        // Rigidbodyに力を加えて発射
        bullets.GetComponent<Rigidbody>().velocity = force;
        // 弾丸の位置を調整
        bullets.transform.position = gameObject.transform.position + gameObject.transform.forward;
    }

}
