using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pipe_spawner : MonoBehaviour
{

    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float speed = 2f;

    private float timer;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    // Update is called once per frame
    private void SpawnPipe()
    {

        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        
        transform.position += Vector3.left * speed * Time.deltaTime;
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
