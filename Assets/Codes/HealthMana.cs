using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMana : MonoBehaviour
{
    public Slider Health;
    public Slider Mana;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxHealth(int health)
    {
        Health.maxValue = health;
        Health.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        Health.value = health;

        fill.color = gradient.Evaluate(Health.normalizedValue);
    }
    public void SetMaxMana(int mana)
    {
        Mana.maxValue = mana;
        Mana.value = mana;
    }
    public void SetMana(int mana) 
    {
        Mana.value = mana;
    }
}
