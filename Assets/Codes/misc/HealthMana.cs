using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       // we call unityengine.ui when we make changes to UI specific components like images, gradients, and text.

public class HealthMana : MonoBehaviour     // testing function for setting and evaluating health and changing the fill gradient based on missing hp.
{
    public Slider Health;           // unity has a simple slider component, we don't use any of the functionality other than value changes.
    public Slider Mana;             // we can use min max value if player health and mana are different and not just (0 to 100).
    public Gradient gradient;       // a gradient component we added to change the color of the image based on set values.
    public Image fill;              // the image we manipulate with colors from the gradient.
    
    public void SetMaxHealth(int health)        // sets max health
    {
        Health.maxValue = health;
        Health.value = health;

        fill.color = gradient.Evaluate(1f);     // gradient evaluation of 1 is a full health bar.
    }
    public void SetHealth(int health)           // modifies health values
    {
        Health.value = health;

        fill.color = gradient.Evaluate(Health.normalizedValue);     // gradiant evaluation of normalized values from 0 to 1 which is for color change.
    }
    public void SetMaxMana(int mana)        // we don't need to change mana base color so we don't need a gradient.
    {
        Mana.maxValue = mana;
        Mana.value = mana;
    }
    public void SetMana(int mana)           // modifies mana values
    {
        Mana.value = mana;
    }
}
