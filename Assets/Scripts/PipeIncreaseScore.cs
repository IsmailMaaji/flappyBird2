using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("PipeIncreaseScore: OnTriggerEnter2D hit: " + (collision != null ? collision.name : "null") + ", tag=" + (collision != null ? collision.tag : "null"));

        if (collision != null && collision.CompareTag("Player"))
        {
            if (Score.instance == null)
            {
                Debug.LogWarning("PipeIncreaseScore: Score.instance is null when trying to increase score.");
            }
            else
            {
                Debug.Log("PipeIncreaseScore: Increasing score for player hit.");
                Score.instance.IncreaseScore();
            }
        }
    }
}
