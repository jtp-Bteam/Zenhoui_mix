using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : AbstractMonoScript
{
    // int hp;
    // int lastDosu = 0;
    // int companionNum = 0; //味方の数

    // private float speed = 500f;
    // float moveX = 0f, moveZ = 0f;

    // [SerializeField]
    // GameObject companion;
    // [SerializeField]
    // GameObject explodObj;

    // // Use this for initialization
    // void Start () {
    //     hp = 5;
    // }

	// // Update is called once per frame
	// void Update () {
    //     Idou();
    //     Kaiten();
    // }

    // void FixedUpdate()
    // {
    //     GetComponent<Rigidbody>().velocity = new Vector3(moveX, 0, moveZ);
    // }

    // private void Idou()
    // {
    //     //ここはAndroid用なのでビルドの際は絶対に有効にし、下のを無効にする

    //     //moveX = CrossPlatformInputManager.GetAxisRaw("HorizontalLeft") * Time.deltaTime * speed;
    //     //moveZ = CrossPlatformInputManager.GetAxisRaw("VerticalLeft") * Time.deltaTime * speed;

    //     //Android用ここまで

    //     moveX = Input.GetAxisRaw("HorizontalLeft") * Time.deltaTime * speed;
    //     moveZ = Input.GetAxisRaw("VerticalLeft") * Time.deltaTime * speed;
    // }

    // private void Kaiten()
    // {
    //     //ここもIdouメソッドと同様にビルドの際は絶対に有効にする

    //     //double radian = System.Math.Atan2(CrossPlatformInputManager.GetAxis("VerticalRight"), CrossPlatformInputManager.GetAxis("HorizontalRight"));

    //     //Android用ここまで

    //     double radian = System.Math.Atan2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));


    //     int dosu = (int)((180 * radian) / System.Math.PI) - 90;
    //     if (CrossPlatformInputManager.GetAxis("VerticalRight") == 0 && CrossPlatformInputManager.GetAxis("HorizontalRight") == 0 && dosu == -270)
    //     {
    //         dosu = lastDosu;
    //     }
    //     else
    //     {
    //         lastDosu = dosu;
    //     }
    //     transform.rotation = Quaternion.Euler(0, -dosu, 0);
    // }

    // public int GetHP()
    // {
    //     return hp;
    // }

    // public void IncreaseSpeed()
    // {
    //     if(speed < 2000) speed += 500;
    // }

    // public void DecreaseSpeed()
    // {
    //     if(speed > 500) speed -= 500;
    // }

    // public void AddCompanion()
    // {
    //     if (companionNum < 4)
    //     {
    //         GameObject com = Instantiate(companion, transform.position, Quaternion.identity);
    //         com.GetComponent<CompanionScript>().Create(companionNum);
    //         companionNum++;
    //     }
    // }

    // public void ApplyThreeWay()
    // {
    //     gameObject.GetComponent<MyShootingScript>().ApplyThreeWay();
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "EnemyBullet")
    //     {
    //         hp--;
    //         if (hp == 0)
    //         {
    //             Instantiate(explodObj, gameObject.transform.position, Quaternion.identity);
    //             Destroy(gameObject);
    //         }
    //     }
    // }

      public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dossun")
        {
            {
             
                Destroy(this.gameObject);
            }
        }
    }
}
