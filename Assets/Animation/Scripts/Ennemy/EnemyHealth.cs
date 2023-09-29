using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool enemyDie=false;
    public Canvas EnemyCanvas;
    public Slider EnemyHPSlider;

    public EnemyController enemyController;

    public bool drop;
    public GameObject theDrop;

    KillCounter KillCounter;

    
    void Awake()
    {
        maxHealth = currentHealth;
        EnemyHPSlider.minValue= 0;
        EnemyHPSlider.maxValue= maxHealth;
        EnemyHPSlider.value= currentHealth;

        enemyController = GetComponent<EnemyController>();
        
        
    }
    private void Start()
    {
        KillCounter = GameObject.Find("KillCounterObject").GetComponent<KillCounter>();
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        EnemyHPSlider.value = currentHealth;
        if (currentHealth <=0)
        {
            enemyDie = true;
            EnemyCanvas.enabled= false;
            Die();
            KillCounter.AddKill();
            
        }
    }

    public void Die()
    {
        enemyController.Death();
        Destroy(gameObject, 2f);
        if (drop)
        {
            Instantiate(theDrop,transform.position,transform.rotation);
        }
    }
}
