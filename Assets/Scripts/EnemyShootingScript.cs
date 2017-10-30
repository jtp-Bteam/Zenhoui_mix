using UnityEngine;
using System.Collections;

public class EnemyShootingScript : AbstractShootingScript
{

    // Use this for initialization
    public override void Start()
    {
        bullet = (GameObject)Resources.Load("Prefabs/EnemyBullet");
        if (gameObject.name == "Enemy")
        {
            InvokeRepeating("Shoot", Random.value, 1f);
            speed = 500 * Time.deltaTime;
        }
    }
}