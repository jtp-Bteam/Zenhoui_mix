using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class SADScript : EnemyScript {

    public Vector3[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Transform player;
    bool Find = false;
    


    public override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        agent.autoBraking = true;
        hp = 50;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint];

        destPoint = (destPoint + 1) % points.Length;
    }

    public override void FixedUpdate()
    {
        Search();
        base.FixedUpdate();
    }


    public override void Idou()
    {
        if(Find)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

    }

    public override void Kaiten()
    {
        if(Find)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            var relativePos = points[destPoint] - transform.position;
            var rotation = Quaternion.LookRotation(relativePos);
            transform.rotation =
              Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }

    }

    public void Search()
    {
        float distance = 15;
        Ray ray = new Ray(transform.position, (player.transform.position - gameObject.transform.position).normalized);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, distance);
        Debug.DrawLine(ray.origin, ray.direction * distance, Color.blue,20);
        Debug.Log(hit.collider.name);


        if (Vector3.Angle((gameObject.transform.position - player.transform.position).normalized, gameObject.transform.forward) <= 140 || !(hit.collider.name == "Player" || hit.collider.tag == "MyBullet"))
        {
            Find = false;
            GetComponent<Light>().color = Color.green;
            agent.speed = 5;
            agent.angularSpeed = 100000;

        }
        else
        {
            Find = true;
            GetComponent<Light>().color = Color.red;
            agent.speed = 15;
            agent.angularSpeed = 100000;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MyBullet")
        {
            hp--;
            if (hp <= 0)
            {
                Instantiate(explodObj, gameObject.transform.position, Quaternion.identity);
                GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<AbstractStageScript>().AddScore();
                Destroy(gameObject);
                GameObject.Find("GyroStage").GetComponent<GyroStageScript>().Invoke("Clear", 3f);
            }
        }
    }
}
