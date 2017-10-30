using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

abstract public class AbstractShootingScript : MonoBehaviour, IShootingScript {

    protected bool endless;

	// bullet prefab
	//[SerializeField]
    protected GameObject bullet;

    // 弾丸発射点
    //public Transform muzzle;

    // 弾丸の速度
    protected float speed;

	// Use this for initialization
	public virtual void Start () {
        bullet = (GameObject)Resources.Load("Prefabs/MyBullet");
		InvokeRepeating("Shoot", 0.1f, 0.1f);
        speed = 1500 * Time.deltaTime;
        if(SceneManager.GetActiveScene().name == "EndlessStage"){
            if(PlayerPrefs.GetInt("CurrentBullet") > 0){
                ApplyThreeWay();
            }
        }
	}

	public virtual void Shoot(){
		// 弾丸の複製
		GameObject bullets = Instantiate(bullet) as GameObject;

        Vector3 force = gameObject.transform.forward * speed;
        // Rigidbodyに力を加えて発射
        bullets.GetComponent<Rigidbody>().velocity = force;
        // 弾丸の位置を調整
        bullets.transform.position = gameObject.transform.position + gameObject.transform.forward;
	}
	public virtual void ApplyThreeWay()
    {
        InvokeRepeating("ThreeWayShoot", 0.1f, 0.1f);
    }

	public virtual void ThreeWayShoot()
    {
        // 弾丸の複製
        GameObject bulletsLeft = Instantiate(bullet) as GameObject;
        GameObject bulletsRight = Instantiate(bullet) as GameObject;

        Vector3 forceLeft = Mathf.Cos(20 * Mathf.Deg2Rad) * gameObject.transform.forward * speed - Mathf.Sin(20 * Mathf.Deg2Rad) * gameObject.transform.right * speed;
        Vector3 forceRight = Mathf.Cos(20 * Mathf.Deg2Rad) * gameObject.transform.forward * speed + Mathf.Sin(20 * Mathf.Deg2Rad) * gameObject.transform.right * speed;
        // Rigidbodyに力を加えて発射
        bulletsLeft.GetComponent<Rigidbody>().velocity = forceLeft;
        bulletsRight.GetComponent<Rigidbody>().velocity = forceRight;
        // 弾丸の位置を調整
        bulletsLeft.transform.position = gameObject.transform.position + Mathf.Cos(20 * Mathf.Deg2Rad) * gameObject.transform.forward - Mathf.Sin(20 * Mathf.Deg2Rad) * gameObject.transform.right;
        bulletsRight.transform.position = gameObject.transform.position + Mathf.Cos(20 * Mathf.Deg2Rad) * gameObject.transform.forward + Mathf.Sin(20 * Mathf.Deg2Rad) * gameObject.transform.right;
    }
}
