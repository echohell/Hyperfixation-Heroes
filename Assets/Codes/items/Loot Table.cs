using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public GameObject droppedItemprefab;                                                // uses prefab created in unity editor (prefab folder)
    public List<Item> lootList = new List<Item>();                                      // new List is Item (passes back item as value)

    Item GetDroppedItem()                                                               // Get the dropped item from the list of items.
    {
        int randomNum = Random.Range(1, 101);                                           // resetting int of random value from 1 to 100 to compare to drop chance
        List<Item> possibleDrops = new List<Item>();                                    // new list is potential drops
        foreach (Item item in lootList)                                                 // for each item found in the initialized loot list
        {
            if (randomNum <= item.dropChance)                                           // if the random number is greater than or equal to drop chance
            {
                possibleDrops.Add(item);                                                // add it to the list to be considered for drops
            }
        }
        if (possibleDrops.Count > 0)                                                    // if there is at least one item in the possible drops
        {
            Item droppedItem = possibleDrops[Random.Range(0,possibleDrops.Count)];      // spit out a random item from that list of added items
            return droppedItem;                                                         // return that item as the one chosen
        }

        return null;                                                                    // returns null if nothing hits the drop chance
    }    

    public void InstantiateLoot(Vector3 initLoc)                                        // instantiating loot presence in game
    {
        int droprate = Random.Range(1,101);                                             // localized int from 1-100
        if (droprate >= 80) droprate = 2;                                               // if drop rate hits 80 or above, drop 2 loot
        else if (droprate < 80) droprate = 1;                                           // if drop rate hits 79 or below, only drop 1 loot

        for (int i = droprate; i > 0; i--) {                                            // iterate through the drop rate provided above
            Item droppedItem = GetDroppedItem();                                        // call dropped item
            if (droppedItem != null)                                                    // as long as dropped item has at least one item, perform this func
            {
                GameObject lootGameObj = Instantiate(droppedItemprefab, initLoc, Quaternion.identity);          // instantiate prefab
                lootGameObj.GetComponent<SpriteRenderer>().sprite = droppedItem.icon;                           // set the sprite to whats provided from item

                float dropForce = 300f;                                                                         // set the vec3 drop force on prefab for push
                Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));                    // set the drop direction that it explodes out from
                lootGameObj.GetComponent<Rigidbody2D>().AddForce(dropDir * dropForce, ForceMode2D.Impulse);     // set impulse on the rigidbody for adding force
                lootGameObj.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));      // change z euler for changing angle

                // this is where animations can go, auto looting, particle effects, when loot is given.
            }
        }
    }
}
