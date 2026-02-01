using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log("FlyBehavior: Start - rb=" + (_rb != null) + ", name=" + gameObject.name + ", tag=" + gameObject.tag);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
                if (_rb != null)
                {
                    _rb.linearVelocity = Vector2.up * _velocity;
                }
        }
    }
    private void FixedUpdate()
    {
            transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("FlyBehavior: OnCollisionEnter2D hit: " + (collision != null && collision.gameObject != null ? collision.gameObject.name : "null") + ", tag=" + (collision != null && collision.gameObject != null ? collision.gameObject.tag : "null"));
        GameMangaer.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FlyBehavior: OnTriggerEnter2D hit: " + (collision != null ? collision.name : "null") + ", tag=" + (collision != null ? collision.tag : "null"));
        if (collision == null) return;

        // If the other trigger already has a PipeIncreaseScore component,
        // it will handle scoring itself — avoid double-counting.
        if (collision.GetComponent<PipeIncreaseScore>() != null) return;

        // Increment score when passing common score trigger tags.
        if (collision.CompareTag("Score") || collision.CompareTag("ScoreZone") || collision.CompareTag("Point"))
        {
            if (Score.instance != null)
            {
                Score.instance.UpdateScore();
            }
        }
    }
}
