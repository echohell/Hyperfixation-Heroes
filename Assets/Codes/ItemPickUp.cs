using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;                               // reference to the scriptable object.

    void Pickup()                                   // calls static inventory manager and adds item.
    {
        InventoryManager.Instance.Add(Item);        // adds item to list.
        Destroy(gameObject);                        // destroys so no duplicates can be picked up.
    }

    private void OnMouseDown()                      // when the player clicks, it performs pickup function. (needs a collider to work)
    {
        Pickup();
    }
}
