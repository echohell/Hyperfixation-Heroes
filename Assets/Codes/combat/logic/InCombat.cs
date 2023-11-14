using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCombat : MonoBehaviour
{
    public PlayerMovement playerMove;

    void OnMouseEnter()
    {
        if (playerMove.isInCombat != true) playerMove.isInCombat = true;
        else playerMove.isInCombat = false;
    }

    //obsolete as of November 14th.
}
