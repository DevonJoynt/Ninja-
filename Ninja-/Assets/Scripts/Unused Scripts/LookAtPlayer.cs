using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILookAtPlayer : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the AI robot to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the rotation needed to look at the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate the robot towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
