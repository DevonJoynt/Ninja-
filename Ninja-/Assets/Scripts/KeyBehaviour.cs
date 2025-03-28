using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // if tag is marked player, key is added to player inventory
        {
           
            InventoryManager.Instance.AddItem(itemType);
            Destroy(gameObject);// destroy game object after added to inventory
        }
    }
}
