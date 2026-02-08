using UnityEngine;
using System.Collections.Generic;

// This line adds a shortcut to your Right-Click menu in Unity!
[CreateAssetMenu(fileName = "NewBase", menuName = "Items/Item Base")]
public class ItemBase : ScriptableObject 
{
    public string baseName;
    public float damage;
    public float attackSpeed;
    public float itemLevel;
    public List<AffixData> possibleAffixes = new List<AffixData>();
    // You can even drag an icon image here
    public Sprite icon; 
}