using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for hover detection

public class inventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    public Image frameImage; // For rarity colors
    public lootItem itemData;

    // Call this when the inventory refreshes
    public void DisplayItem(lootItem newItem)
    {
        itemData = newItem;
        iconImage.sprite = itemData.baseData.icon;
        iconImage.enabled = true;
        
        // Optional: Change frame color based on rarityLevel
        // frameImage.color = GetRarityColor(itemData.rarity);
    }

   public void OnPointerEnter(PointerEventData eventData)
{
    if (itemData != null)
    {
        // Pass 'transform.position' so the tooltip knows where the slot is
        tooltipManager.Show(itemData, transform.position);
    }
}

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipManager.Hide();
    }
}