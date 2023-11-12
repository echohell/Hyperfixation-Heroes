using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, Idamaging       // inherit so crates can be damaged.
{
    public GameObject thisObj;                      // public for inspector attach.
    public void DamageCalc()                        // since this is Idamaging, it needs to have the DamageCalc function.
    {
        GameObject.Destroy(thisObj);                // just destroy the crate when damaged.
    }
}
