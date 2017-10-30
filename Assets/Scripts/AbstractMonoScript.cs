using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

abstract public class AbstractMonoScript : MonoBehaviour, MonoScript
{
    protected int hp;
    protected int lastDosu = 0;
    protected int companionNum; //味方の数

    protected float speed;
    protected float moveX = 0f, moveZ = 0f;
    
    protected GameObject companion;
    protected GameObject explodObj;

    // Use this for initialization
    public virtual void Start () {
        companion = (GameObject)Resources.Load("Prefabs/MyCompanion");
        explodObj = (GameObject)Resources.Load("Prefabs/ExplosionMobile");

        if (SceneManager.GetActiveScene().name == "EndlessStage"){
            hp = PlayerPrefs.GetInt("CurrentHP", 10);
            companionNum = PlayerPrefs.GetInt("CurrentCompanion", 0);
            speed = (PlayerPrefs.GetInt("CurrentSpeed", 0) + 1) * 500f;
        }

        else{
            hp = 10;
            companionNum = 0;
            speed = 500f;
        }

        int i;
        for (i = 0; i < companionNum; i++) AddCompanion();
    }

	// Update is called once per frame
	public virtual void Update () {
    }

    public virtual void FixedUpdate()
    {
        Idou();
        Kaiten();
    }

    public virtual void Idou(){

        //ここはAndroid用なのでビルドの際は絶対に有効にし、下のを無効にする

        moveX = CrossPlatformInputManager.GetAxisRaw("HorizontalLeft") * Time.deltaTime * speed;
        moveZ = CrossPlatformInputManager.GetAxisRaw("VerticalLeft") * Time.deltaTime * speed;

        //Android用ここまで

        //moveX = Input.GetAxisRaw("HorizontalLeft") * Time.deltaTime * speed;
        //moveZ = Input.GetAxisRaw("VerticalLeft") * Time.deltaTime * speed;

        GetComponent<Rigidbody>().velocity = new Vector3(moveX, 0, moveZ);
    }

    public virtual void Kaiten()
    {
        //ここもIdouメソッドと同様にビルドの際は絶対に有効にする

        double radian = System.Math.Atan2(CrossPlatformInputManager.GetAxis("VerticalRight"), CrossPlatformInputManager.GetAxis("HorizontalRight"));

        //Android用ここまで

        //double radian = System.Math.Atan2(Input.GetAxisRaw("VerticalRight"), Input.GetAxisRaw("HorizontalRight"));



        int dosu = (int)((180 * radian) / System.Math.PI) - 90;
        if (CrossPlatformInputManager.GetAxis("VerticalRight") == 0 && CrossPlatformInputManager.GetAxis("HorizontalRight") == 0 && dosu == -270)
        {
            dosu = lastDosu;
        }
        else
        {
            lastDosu = dosu;
        }
        transform.rotation = Quaternion.Euler(0, -dosu, 0);
    }

    public virtual int GetHP()
    {
        return hp;
    }

    public virtual void DecreaseHP(){
        hp--;
        if (hp <= 0)
        {
//            Instantiate(explodObj, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public virtual void IncreaseSpeed()
    {
        if(speed < 2000) speed += 500;
    }

    public virtual void DecreaseSpeed()
    {
        if(speed > 500) speed -= 500;
    }

    public virtual void IncreaseHP()
    {
        hp++;
    }

    public virtual void AddCompanion()
    {
        if (companionNum < 4)
        {
            GameObject com = Instantiate(companion, transform.position, Quaternion.identity);
            com.GetComponent<CompanionScript>().Create(companionNum);
            companionNum++;
        }
    }

    public virtual void ApplyThreeWay()
    {
        gameObject.GetComponent<MyShootingScript>().ApplyThreeWay();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet") //弾に当たったときの挙動
        {
            DecreaseHP();
        }
    }

    public virtual void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "FrontWall"){
            transform.position = new Vector3(transform.position.x, transform.position.y, col.transform.position.z - (float)1.1);
        }
        else if(col.gameObject.name == "BackWall"){
            transform.position = new Vector3(transform.position.x, transform.position.y, col.transform.position.z + (float)1.1);
        }
        else if(col.gameObject.name == "LeftWall"){
            transform.position = new Vector3(col.transform.position.x + (float)1.1, transform.position.y, transform.position.z);
        }
        else if(col.gameObject.name == "RightWall"){
            transform.position = new Vector3(col.transform.position.x - (float)1.1, transform.position.y, transform.position.z);
        }
        else if(col.gameObject.tag == "Obstacle")
        {
            DecreaseHP();
        }
    }
}
