using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //player loses health if comes in contact with enemy
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
