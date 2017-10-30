using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmartEnemyScript : EnemyScript {

    // Update is called once per frame
    public override void Idou()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Transform player1 = GameObject.Find("Player").transform;
        agent.SetDestination(player1.position);
    }
}
