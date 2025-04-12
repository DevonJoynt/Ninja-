using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemEvent : UnityEvent<InventoryManager.AllItems> { }

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllItems> inventoryItems = new List<AllItems>();   //list of all items currently in player inventory

    // Add Unity Events
    [Header("Events")]

    public ItemEvent onItemAdded = new ItemEvent();   //events fire when item added to inventory
    public ItemEvent onItemRemoved = new ItemEvent();   //events fire when items are removed from inventory

    private void Awake()
    {
        Instance = this;   //ensures only one manager exists

        onItemAdded.AddListener(inventoryItems.Add);   //adds items to inventory list when the onItemAdded event is fired
    }

    public void AddItem(AllItems item)   //adds the item if it's not already in inventory
    {
        if (!inventoryItems.Contains(item))   //inventoryItems.Add(item);
        {
      
            // Fire the event
            onItemAdded.Invoke(item);
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (inventoryItems.Contains(item))   //removes item if it exists in inventory
        {
            inventoryItems.Remove(item);   //remove item from inventory list

            // Fire the event
            onItemRemoved.Invoke(item);
        }
    }

    public enum AllItems   //collectible items in game
    {
        PurpleKey,
        RedKey,
        GreenKey
    }
}