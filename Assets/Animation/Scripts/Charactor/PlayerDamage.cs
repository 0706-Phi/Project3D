using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public float playerDamage;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;
    
    public GameObject PlayergameObject;
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    private void FixedUpdate()
    {
        if(playerInRange == true)
        {
            DamagePlayer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerHealth>().playerDie == false)
            {
                PlayergameObject = other.gameObject;
                playerInRange = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }



    public void DamagePlayer()
    {
        if(nextDamage <= DateTime.Now)
        {
            if (PlayergameObject.GetComponent<PlayerHealth>().playerDie == false)
            {
                PlayergameObject.GetComponent<PlayerHealth>().AddDamage(playerDamage);
               
            }
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }

}
