using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamaging      // interface is like inheritance, makes things easier.
{
    void DamageCalc();         // all classes that inherit from Idamaging must have a Damage Calculation Function.
}

