using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemEvent : UnityEvent<InventoryManager.AllItems> { }

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllItems> inventoryItems = new List<AllItems>();

    // Add Unity Events
    [Header("Events")]
    public ItemEvent onItemAdded = new ItemEvent();
    public ItemEvent onItemRemoved = new ItemEvent();

    private void Awake()
    {
        Instance = this;
        onItemAdded.AddListener(inventoryItems.Add);
    }

    public void AddItem(AllItems item)
    {
        if (!inventoryItems.Contains(item))
        {
            //inventoryItems.Add(item);
            // Fire the event
            onItemAdded.Invoke(item);
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            // Fire the event
            onItemRemoved.Invoke(item);
        }
    }

    public enum AllItems
    {
        PurpleKey,
        RedKey,
        GreenKey
    }
}