using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes : MonoBehaviour
{
    [SerializeField] private float speed = 0.6f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
