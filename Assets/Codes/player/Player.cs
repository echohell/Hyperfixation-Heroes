using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour                     // basic player script that holds health values.
{
    public int maxHealth = 100;                         // defaulted max health for testing.
    public int currentHealth;                           // int for manipulating hp.

    public HealthMana healthBar;                        // reference to health and mana script
    void Start()
    {
        currentHealth = maxHealth;                      // set current health to max health on start
        healthBar.SetMaxHealth(maxHealth);              // set the health bar max value, determined by our player maxhealth.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))            // testing damage in intervals of 20 by pressing spacebar.
        {
            TakeDamage(20);                             // function that passes in a set value of 20.
        }
    }

    void TakeDamage(int damage)                         // simple health manipulation function.
    {
        currentHealth -= damage;                        // deducts health.

        healthBar.SetHealth(currentHealth);             // updates health from health and mana script.
    }
}
