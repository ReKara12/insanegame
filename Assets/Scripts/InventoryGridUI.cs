using UnityEngine;
using UnityEngine.UI;

public class InventoryGridUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform gridParent;
    public GameObject slotPrefab;

    private void Awake()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();

        if (inventory != null)
            inventory.OnInventoryChanged += Refresh;

        Refresh();
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OnInventoryChanged -= Refresh;
    }

    private void Refresh()
    {
        if (inventory == null || gridParent == null || slotPrefab == null) return;

        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        foreach (var kvp in inventory.Items)
        {
            var go = Instantiate(slotPrefab, gridParent);
            var img = go.GetComponentInChildren<Image>();
            var txt = go.GetComponentInChildren<Text>();
            if (img) img.sprite = kvp.Key.icon;
            if (txt) txt.text = kvp.Value.ToString();
        }
    }
}
