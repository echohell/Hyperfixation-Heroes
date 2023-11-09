using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;
    public EquipType equipType;

    public enum ItemType
    {
        Consumable, Equip, Special, Quest, Pet
    }

    public enum EquipType
    {
        None, Head, Chest, Legs, Boots, Neck, MainHand, OffHand, Gloves, Ring1, Ring2, Trinket, Shoulder, Cape, Belt
    }
}
