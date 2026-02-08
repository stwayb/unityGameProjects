using System.Collections.Generic;
using UnityEngine;
using System; // Required for Action

public class mainManager : MonoBehaviour
{
    public float health = 100;
    public float atkDmg = 10;
    public float atkSpd = 1;
    public float critChance = 0.1f;
    public float critDmg = 1.5f;

    // Use your class name here (lootItem or ItemInstance)
    public List<lootItem> inventory = new List<lootItem>();

    // This "Event" tells the UI to refresh whenever we add an item
    public static event Action OnInventoryUpdated;

    public static mainManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this method instead of adding to the list directly
    public void AddToInventory(lootItem newItem)
    {
        inventory.Add(newItem);
        
        // This triggers the refresh in the UI
        OnInventoryUpdated?.Invoke(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Note: FindAnyObjectByType is slow, but okay for testing 'L' key
            FindAnyObjectByType<generateLoot>().DropLoot();
        }
    }
}