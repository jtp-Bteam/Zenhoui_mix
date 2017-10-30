using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : AbstractMonoScript{
    Rigidbody rigidbody;
    float existtime;

    // Use this for initialization
    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        hp = 1;
        existtime = 0;
    }

    // Update is called once per frame
    void Update(){

    }

    public override void FixedUpdate()
    {
        if (rigidbody.position.y <= transform.localScale.y)
        {
            Vector3 haeru = transform.position;
            haeru.y += 0.05f;
            transform.position = haeru;
        }

        existtime += Time.deltaTime;
        if(existtime >= 10)
        {
            Destroy(gameObject);
        }
    }
}
