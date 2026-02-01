using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hoops_increase : MonoBehaviour
{
    private bool playerPassed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPassed = true;
            score.instance.increaseScore();
        }
    }

    private void FixedUpdate()
    {
        // Check if player passed the hoop without entering the trigger
        if (!playerPassed)
        {
            // If the hoop is to the left of the player's position, player missed it
            if (transform.position.x < -7) // Adjust threshold as needed
            {
                GameManager.instance.GameOver();
                Destroy(gameObject);
            }
        }
    }
}
