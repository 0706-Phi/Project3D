using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public bool playerDie = false;
    public Canvas playerCanvas;
    public Slider PlayerHPSlider;
    public AudioSource AudioSource;

    Movement move;

    public GameOver gameOver;
    void Awake()
    {
        currentHealth = maxHealth;
        PlayerHPSlider.minValue = 0;
        PlayerHPSlider.maxValue = maxHealth;
        PlayerHPSlider.value = currentHealth;

        move= GetComponent<Movement>();
    }
   
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        PlayerHPSlider.value = currentHealth;
        if(currentHealth <= 0 )
        {
            playerDie = true;
            playerCanvas.enabled = false;
            Die();
            gameOver.OverGame();
            move.enabled = false;
            
        }
    }

    public void Addhealth(float HealthAmount) 
    {
        currentHealth += HealthAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            PlayerHPSlider.value = currentHealth;
            AudioSource.Play();

        }
    }
    public void Die()
    {
        move.Death();
        Destroy(gameObject, 20f);

    }
   
}
