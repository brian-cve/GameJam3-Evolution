using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class VehiclesAI : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnPosX = 0;
    private float spawnPosZ = 0;
    private float startDelay = 2.0f;
    private float spawnRate = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, spawnRate);

    }
    void Update()
    {

    }
    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 40, Random.Range(spawnPosZ, -314));
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);

    }
}
