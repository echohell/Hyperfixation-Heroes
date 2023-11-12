using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTesting : MonoBehaviour                                              // simple damage testing to make sure Idamaging Interface is working.
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))                                                // checking for left mouse click.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                // send a ray from camera point.
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);       // send a 2D collider to confirm hit.

            if (hit.collider != null)                                                   // if the collider is not null,
            {
                Idamaging idamaging = hit.collider.GetComponent<Idamaging>();           // make the idamaging interface of the collision hit of the object.
                if (idamaging != null)                                                  // if it is something that can be damaged via Idamaging,
                {
                    idamaging.DamageCalc();                                             // perform the DamageCalc Function.
                }
            }
        }
    }
}
