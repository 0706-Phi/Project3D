using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyFightRange=false;

    public GameObject gameOb;
    void Awake()
    {
        nextDamage= DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyFightRange == true)
        {
            DamageEnemy();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameOb = other.gameObject;
            enemyFightRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyFightRange = false;
        }
    }



    public void DamageEnemy()
    {
        if(nextDamage <= DateTime.Now)
        {
            if(gameOb.GetComponent<EnemyHealth>().enemyDie == false)
            {
                gameOb.GetComponent<EnemyHealth>().AddDamage(enemyDamageAmount);
            }
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
