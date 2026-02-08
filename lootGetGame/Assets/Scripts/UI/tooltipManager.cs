using TMPro;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for hover detection

public class tooltipManager : MonoBehaviour
{
    public static tooltipManager Instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI statsText;
    public GameObject visualPanel;

    void Awake() => Instance = this;

    public static void Show(lootItem item, Vector3 slotPosition)
    {
        if (Instance == null) return;
        Instance.visualPanel.SetActive(true);
        // 1. Position the tooltip offset from the slot
        // We add an offset (e.g., 75 pixels right, -25 pixels down)
        Vector3 offset = new Vector3(-200, -20, 0);
        Instance.transform.position = slotPosition + offset;

        Instance.nameText.text = item.itemName;
        StringBuilder sb = new StringBuilder();
        
        // Add the implicit base damage
        sb.AppendLine($"Damage: {item.totalDamage:F1}");
        sb.AppendLine("<color=#888888>-------------------</color>");

        // Add the rolled explicit affixes
        foreach (var roll in item.rolledAffixes)
        {
            // Format: "+12% Fire Damage"
            sb.AppendLine($"{roll.affixSource.affixName}: {roll.rolledValue:F1}");
        }

        Instance.statsText.text = sb.ToString();

        // 3. Ensure the tooltip is fully visible on screen
        Instance.EnsureVisible();
    }

    private void EnsureVisible()
    {
        RectTransform rect = visualPanel.GetComponent<RectTransform>();
        
        // 1. Get the current position
        Vector3 pos = transform.position;

        // 2. Calculate the boundaries
        // We use the rect.sizeDelta to know how wide/tall the tooltip is
        float halfWidth = (rect.rect.width * transform.lossyScale.x) / 2;
        float halfHeight = (rect.rect.height * transform.lossyScale.y) / 2;

        // 3. Clamp the X position
        // This ensures the left edge and right edge stay inside Screen.width
        float minX = halfWidth;
        float maxX = Screen.width - halfWidth;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // 4. Clamp the Y position
        float minY = halfHeight;
        float maxY = Screen.height - halfHeight;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // 5. Apply the clamped position
        transform.position = pos;
    }

    public static void Hide() => Instance.visualPanel.SetActive(false);
}