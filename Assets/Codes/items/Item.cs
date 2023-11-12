using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Item",menuName ="Item/Create New Item")]      // this makes a quick option when you right click in the unity panel.
public class Item : ScriptableObject            // scriptable objects are created to store large quantities of shared data.
{
    public int id;                   // item id for drop tables
    public string itemName;          // item name for display
    public string Description;       // description of item
    public int value;                // data set values (can be inherent value or damage value, up to be changed)
    public Sprite icon;              // the image sprite
    public ItemType itemType;        // enum below gives a dropdown to specify the use
    public EquipType equipType;      // enum specifically for equippable items

    public enum ItemType             // can be expanded at a later time to include other values like gold and gems
    {
        Consumable, Equip, Special, Quest, Pet
    }

    public enum EquipType            // our current list of equippable items
    {
        None, Head, Chest, Legs, Boots, Neck, MainHand, OffHand, Gloves, Ring1, Ring2, Trinket, Shoulder, Cape, Belt
    }
}
