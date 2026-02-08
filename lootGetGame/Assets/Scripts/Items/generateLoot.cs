using System.Collections.Generic;
using UnityEngine;

public class generateLoot : MonoBehaviour
{
    // Drag all your ScriptableObject files into this list in the Inspector
    public List<ItemBase> possibleBases; 

    public void DropLoot() 
{
        // Pick a random base from the list
        ItemBase randomBase = possibleBases[Random.Range(0, possibleBases.Count)];
        
        // Now create the "Actual" item using that data
        lootItem newItem = new lootItem();
        newItem.Generate(randomBase, Random.Range(1, 7)); // Random rarity between 1 and 6
        
        Debug.Log("You found a " + newItem.itemName + " with " + newItem.totalDamage + " damage!");
        mainManager.Instance.AddToInventory(newItem);
    }
}