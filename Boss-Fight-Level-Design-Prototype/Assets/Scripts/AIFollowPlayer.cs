using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float moveSpeed = 3f; // Speed at which the AI moves

    private void Update()
    {
        // Check if the player is assigned
        if (player != null)
        {
            // Move the AI towards the player
            Vector3 direction = player.position - transform.position;
            direction.z = 0; // Ensure AI stays in 2D plane
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
    }
}