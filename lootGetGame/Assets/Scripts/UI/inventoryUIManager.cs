using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for hover detection

public class inventoryUIManager : MonoBehaviour
{
    public GameObject slotPrefab; // The button with InventorySlotUI script
    public Transform gridParent;  // The object with the Grid Layout Group component

    private void OnEnable()
    {
        // Subscribe to the event: "When inventory updates, run RefreshGrid"
        mainManager.OnInventoryUpdated += RefreshGrid;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        mainManager.OnInventoryUpdated -= RefreshGrid;
    }

    public void RefreshGrid()
    {
        // 1. Clear the old visual slots
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // 2. Create new slots based on the mainManager's list
        foreach (lootItem item in mainManager.Instance.inventory)
        {
            GameObject newSlot = Instantiate(slotPrefab, gridParent);
            
            // Get the script on the prefab and give it the item data
            newSlot.GetComponent<inventorySlotUI>().DisplayItem(item);
        }
    }
}