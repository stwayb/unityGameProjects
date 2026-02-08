using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class lootItem
{
public ItemBase baseData;
    public string itemName;
    
    // The specific rolls for this unique drop
    public float totalDamage; // Base damage + affix bonuses
    public float attackSpeed; // Base attack speed + affix bonuses
    public List<AffixRoll> rolledAffixes = new List<AffixRoll>();

    public void Generate(ItemBase baseToUse, int rarityLevel) {
        baseData = baseToUse;
        

        
        // 1 Roll Affixes based on rarity (Magic = 1-2, Rare = 3-6)
        for (int i = 0; i < rarityLevel; i++) {
            AffixData randomAffix = baseData.possibleAffixes[Random.Range(0, baseData.possibleAffixes.Count)];
            float roll = Random.Range(randomAffix.minRoll, randomAffix.maxRoll);
            rolledAffixes.Add(new AffixRoll(randomAffix, roll));
        }
        
        // 2. Calculate total damage (base + affix bonuses)
        totalDamage = baseData.damage;
        foreach (AffixRoll roll in rolledAffixes) 
        {
            if (roll.affixSource.statToModify == StatType.Damage)
                totalDamage += roll.rolledValue;
            if (roll.affixSource.statToModify == StatType.AttackSpeed)
                attackSpeed += roll.rolledValue;
        }

        // 3. Construct the Name (e.g., "Sharp Iron Dagger of Haste")
        UpdateName();

    }

    public void UpdateName() 
{
    string prefix = "";
    string suffix = "";

    foreach (AffixRoll roll in rolledAffixes) 
    {
        if (roll.affixSource.type == AffixType.Prefix)
            prefix = roll.affixSource.affixName + " "; 
        
        if (roll.affixSource.type == AffixType.Suffix)
            suffix = " of " + roll.affixSource.affixName;
    }

    itemName = prefix + baseData.baseName + suffix;
    // Result: "Sharp Iron Dagger of Haste"
}
}