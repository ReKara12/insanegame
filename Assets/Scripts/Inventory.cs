using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly Dictionary<ItemData, int> _items = new Dictionary<ItemData, int>();

    public IReadOnlyDictionary<ItemData, int> Items => _items;

    public event System.Action OnInventoryChanged;

    public void AddItem(ItemData item)
    {
        if (item == null) return;

        if (_items.ContainsKey(item))
            _items[item]++;
        else
            _items[item] = 1;

        Debug.Log($"Added {item.itemName} to inventory. Total: {_items[item]}");

        OnInventoryChanged?.Invoke();
    }
}