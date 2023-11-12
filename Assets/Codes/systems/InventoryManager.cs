using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour               // simple inventory manager that uses a list to add items picked up.
{
    public static InventoryManager Instance;            // static makes it so there is only one inventory manager and it can be referenced without confusion.
    public List<Item> Items = new List<Item>();         // new list to add to the inventory. item is a scriptable object. (refer to Item.cs)

    public Transform ItemContent;                       // transform tracks position, rotation and scale.
    public GameObject InventoryItem;                    // gameobject is the base variable that can hold and be basically anything. Used to created inventory items.

    private void Awake()
    {
        Instance = this;                 // on awake, instantiate so there is no secondary inventory managers.
    }

    public void Add(Item item)          // function for adding items, gets called when we want to pick up items. (Found in ItemPickUp.cs)
    {
        Items.Add(item);
    }

    public void Remove(Item item)       // function for removing items, not currently in use. (will be used when we make a salvage system)
    { 
        Items.Remove(item);
    }

    public void ListItems()                                 // called when we want to view the items we have sent to the inventory.
    {
        foreach (Transform item in ItemContent)              // for each loop that destroys item duplicates if any are found. Needs optimization.
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)                     // for each item in the items list, instantiate a game object to see in inventory.
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);                               // init. Needs optimization. .Find is slow.
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();          // tracks down item name from text mesh pro.
            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();                   // tracks down sprite image from icon.

            itemName.text = item.itemName;                                                          // We have to find the image first, and then
            itemIcon.sprite = item.icon;                                                            // set text and sprite from Item.cs
        }
    }
}
