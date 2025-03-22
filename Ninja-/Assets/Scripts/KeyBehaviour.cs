using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    //[SerializeField] SwitchBehaviour switchbehaviour;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //switchbehaviour.DoorLockedStatus();
            InventoryManager.Instance.AddItem(itemType);
            Destroy(gameObject);
        }
    }
}
