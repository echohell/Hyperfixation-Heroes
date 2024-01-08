using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public GameObject droppedItemprefab;
    public List<Item> lootList = new List<Item>();

    Item GetDroppedItem()
    {
        int randomNum = Random.Range(1, 101);
        List<Item> possibleDrops = new List<Item>();
        foreach (Item item in lootList)
        {
            if (randomNum <= item.dropChance)
            {
                possibleDrops.Add(item);
            }
        }
        if (possibleDrops.Count > 0)
        {
            Item droppedItem = possibleDrops[Random.Range(0,possibleDrops.Count)];
            return droppedItem;
        }

        return null;            // if nothing is dropped somehow.
    }    

    public void InstantiateLoot(Vector3 initLoc)
    {
        int droprate = Random.Range(1,101);
        if (droprate >= 80) droprate = 2;
        else if (droprate < 80) droprate = 1;

        for (int i = droprate; i > 0; i--) {
            Item droppedItem = GetDroppedItem();
            if (droppedItem != null)
            {
                GameObject lootGameObj = Instantiate(droppedItemprefab, initLoc, Quaternion.identity);
                lootGameObj.GetComponent<SpriteRenderer>().sprite = droppedItem.icon;

                float dropForce = 300f;
                Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                lootGameObj.GetComponent<Rigidbody2D>().AddForce(dropDir * dropForce, ForceMode2D.Impulse);
                lootGameObj.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));

                // this is where animations can go, auto looting, particle effects, when loot is given.
            }
        }
    }
}
