using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pipe_increase_score : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            score.instance.increaseScore();
        }
    }
}
