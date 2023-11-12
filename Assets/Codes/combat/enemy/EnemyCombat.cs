using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, Idamaging         // inherit Idamaging so enemy can take damage.
{
    public GameObject thisObj;                              // basic placeholder script.
    public void DamageCalc()                                // Idamaging needs this script as an interface.
    {
        GameObject.Destroy(thisObj);                        // basic placeholder destroy instead of taking damage logic.
    }
}
