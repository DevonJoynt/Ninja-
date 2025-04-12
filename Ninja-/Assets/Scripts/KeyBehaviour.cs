using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;

    // Add Unity Events
    [Header("Events")]
    //event fires when key is collected
    public UnityEvent<InventoryManager.AllItems> onKeyCollected = new UnityEvent<InventoryManager.AllItems>();

    private bool isCollected = false;   //stops key from being collected more than once
    
    // Event Listener
    private void Start()
    {
        //when key is collected, automatically added to inventory
        onKeyCollected.AddListener(InventoryManager.Instance.AddItem);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player")) //collect key if not collected yet
        {
            isCollected = true;   //mark key as collected

            // Fire the event
            onKeyCollected.Invoke(itemType);

            // Add the key to inventory
            

            // Hide the key
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            GetComponent<Collider2D>().enabled = false;

            // Destroy the key
            Destroy(gameObject, 0.1f);
        }
    }
}