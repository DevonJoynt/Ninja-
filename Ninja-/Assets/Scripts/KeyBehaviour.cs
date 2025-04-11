using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;

    // Add Unity Events
    [Header("Events")]
    public UnityEvent<InventoryManager.AllItems> onKeyCollected = new UnityEvent<InventoryManager.AllItems>();

    private bool isCollected = false;
    // Event Listener
    private void Start()
    {
        onKeyCollected.AddListener(InventoryManager.Instance.AddItem);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;

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