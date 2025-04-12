using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventHandler : MonoBehaviour
{
    [Header("Key UI")]
    //references UI Key Images
    [SerializeField] private Image purpleKeyImage;
    [SerializeField] private Image redKeyImage;
    [SerializeField] private Image greenKeyImage;

    [Header("Key Colors")]
    [SerializeField] private Color activeKeyColor = Color.white;
    [SerializeField] private Color inactiveKeyColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    void Start()
    {
        // Set initial UI state
        UpdateKeyUI();

        // Subscribe to events from InventoryManager
        if (InventoryManager.Instance != null)
        {
            //listens for both added and removed items
            InventoryManager.Instance.onItemAdded.AddListener(OnItemChanged);
            InventoryManager.Instance.onItemRemoved.AddListener(OnItemChanged);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from events
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.onItemAdded.RemoveListener(OnItemChanged);
            InventoryManager.Instance.onItemRemoved.RemoveListener(OnItemChanged);
        }
    }

    // Handle item change events
    private void OnItemChanged(InventoryManager.AllItems item)
    {
       //update ui to reflect inventory changes
        UpdateKeyUI();
    }

    // Update the UI based on inventory
    private void UpdateKeyUI()
    {
       //make sure inventory exists
        if (InventoryManager.Instance == null) return;

        // Update purple key
        if (purpleKeyImage != null)
        {
            bool hasPurpleKey = InventoryManager.Instance.inventoryItems.Contains(InventoryManager.AllItems.PurpleKey);  //check if player has purple key
            purpleKeyImage.color = hasPurpleKey ? activeKeyColor : inactiveKeyColor;
        }

        // Update red key
        if (redKeyImage != null)
        {
            bool hasRedKey = InventoryManager.Instance.inventoryItems.Contains(InventoryManager.AllItems.RedKey);  //check if player has red key
            redKeyImage.color = hasRedKey ? activeKeyColor : inactiveKeyColor;
        }

        // Update green key
        if (greenKeyImage != null)
        {
            bool hasGreenKey = InventoryManager.Instance.inventoryItems.Contains(InventoryManager.AllItems.GreenKey);  //check if player has green key
            greenKeyImage.color = hasGreenKey ? activeKeyColor : inactiveKeyColor;
        }
    }
}