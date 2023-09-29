using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float Healthamount;

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth theplayerHealth = other.GetComponent<PlayerHealth>();
            theplayerHealth.Addhealth(Healthamount);
            Destroy(gameObject);
        }
    }
}
