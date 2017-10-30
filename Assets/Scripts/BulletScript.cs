using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        bool judge1 = !((gameObject.name == "MyBullet(Clone)") && (other.name == "Player"));
        bool judge2 = gameObject.name.Substring(0, 2) != other.name.Substring(0, 2);
        if (judge1 && judge2) Destroy(gameObject);
    }
}
