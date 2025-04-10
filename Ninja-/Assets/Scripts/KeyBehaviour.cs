using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;

    // Add Unity Events
    [Header("Events")]
    public UnityEvent onKeyCollected = new UnityEvent();

    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;

            // Fire the event
            onKeyCollected.Invoke();

            // Add the key to inventory
            InventoryManager.Instance.AddItem(itemType);

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