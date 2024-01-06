using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Skill",menuName ="Skill/Create New Skill")]      // this makes a quick option when you right click in the unity panel.
public class Skill : ScriptableObject            // scriptable objects are created to store large quantities of shared data.
{
    public int id;                          // skill id for ability tables
    public string skillName;                // skill name for display
    public string Description;              // description of item
    public float damage;                    // data set values (can be inherent value or damage value, up to be changed)
    public int range;                       // how many tiles away the skill can hit
    public Sprite reticle;                  // how many tiles from target (ie: 0 = target, 1 = cross, 2 = diamond, etc)
    public Sprite icon;                     // the image sprite
    public SkillType skillType;             // enum allows categorization for future cals (int scaling vs str scaling etc)
    public ElementType elementType;         // enum to determine elemental mods
    public EffectType effectType;           // enum for secondary effects

    public enum SkillType                   // to be reviewed later for addt'l categories
    {
        Magic, Ability, Passive, Reactive
    }

    public enum ElementType                 // our current list of elemental modifiers
    {
        Neutral, Fire, Water, Earth, Wind, Holy, Dark, Arcane
    }

    public enum EffectType                  // what potential persistent effect the spell has
    { 
        None, Immobilise, Stun, Silence, Cripple, Burn, Poison, Bleed, Paralyze, Undead, StatusRes, HoT, Reraise, Shield, ElementRes
    }
}
