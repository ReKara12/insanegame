using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Text displayText;

    private void Awake()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }
        if (inventory != null)
        {
            inventory.OnInventoryChanged += UpdateUI;
        }
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OnInventoryChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        if (inventory == null || displayText == null) return;

        StringBuilder sb = new StringBuilder();
        foreach (var kvp in inventory.Items)
        {
            sb.AppendLine($"{kvp.Key.itemName} x{kvp.Value}");
        }
        displayText.text = sb.ToString();
    }
}
