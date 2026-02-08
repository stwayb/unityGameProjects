using System.Collections.Generic;
using UnityEngine;


public enum AffixType { Prefix, Suffix }
public enum StatType { Damage, AttackSpeed, Health, CritChance, CritDamage }

[CreateAssetMenu(fileName = "NewAffix", menuName = "Items/Affix")]
public class AffixData : ScriptableObject {
    public string affixName;
    public AffixType type;
    public StatType statToModify;
    public float minRoll;
    public float maxRoll;
}

[System.Serializable]
public class AffixRoll 
{
    public AffixData affixSource; // Reference to the ScriptableObject (The "Sharp" template)
    public float rolledValue;     // The actual number (e.g., 12.5)

    // A simple constructor to make creating it easy
    public AffixRoll(AffixData data, float value) 
    {
        this.affixSource = data;
        this.rolledValue = value;
    }
}