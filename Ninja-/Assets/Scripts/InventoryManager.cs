using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> inventoryItems = new List<AllItems>();  //Our Inventory Items

    private void Awake()
    {
        Instance = this;
    }
    public void AddItem(AllItems item)   //Add Items to Inventory
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
        }       
    }
    public void RemoveItem(AllItems item) //Remove items from inventory
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
        } 
    }
    public enum AllItems // list of all available inventory items that can be picked up
    {
        PurpleKey,
        RedKey,
        GreenKey

    }
    
}
