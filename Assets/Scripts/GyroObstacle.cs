using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void FixedUpdate () {
        var dir = Vector3.zero;

        // ターゲット端末の縦横の表示に合わせてremapする
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime*500;

        // Move object
        GetComponent<Rigidbody>().velocity = dir;

    }
}
