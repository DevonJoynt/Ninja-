using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point") // if game object has tag of weak point and ocmes in contact with player
        {
            Destroy(collision.gameObject); // object is destroyed.
        }
    }

}
