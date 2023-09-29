using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform transformPlayer;
    public Animator animatorEnemy;
    public bool playerInDetection = false ;

    public PlayerHealth playerHealth;
    public GameObject detectionFight;

   
    
    void Awake()
    {
        agent= GetComponent<NavMeshAgent>();
        animatorEnemy = GetComponent<Animator>();
        
    }


    void FixedUpdate()
    {
        
        if (playerInDetection == true)
        {
            if (playerHealth.playerDie == true)
            {
                agent.transform.LookAt(transformPlayer);
                Idle();
                detectionFight.SetActive(false);
            }
            else
            {
                agent.transform.LookAt(transformPlayer);
                agent.SetDestination(transformPlayer.position + new Vector3(0, 0, 2f));
            }

        }
    }

    public void Run()
    {
        agent.speed = 1f ;
        animatorEnemy.SetTrigger("Run") ;
        
    }
    public void Attack()
    {
        animatorEnemy.SetTrigger("Attack");
    }

    public void Idle()
    {
        
        animatorEnemy.SetTrigger("Idle");
    }

    public void Death()
    {
        agent.speed = 0f;
        animatorEnemy.SetTrigger("Death");
    }

    
}
