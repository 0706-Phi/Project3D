using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionFight : MonoBehaviour
{
    public bool EnemyDetectionFight = false;
    public DateTime nextDamage;
    public float FightAfterTime;

    public EnemyController enemyController;
    public AudioSource audioEne;

    void Awake()
    {
        nextDamage= DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(EnemyDetectionFight == true)
        {
            EDetectionFight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyDetectionFight = true;
            audioEne.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyDetectionFight = false;
        }
    }

    public void EDetectionFight()
    {
        if(nextDamage <= DateTime.Now)
        {
            enemyController.Attack();
            nextDamage= DateTime.Now.AddSeconds(System.Convert.ToDouble(FightAfterTime));
        }
    }
}
