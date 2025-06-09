using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;          // Prefab of the ball to spawn
    public Transform playerCamera;         // Reference to the player's camera (for positioning)

    public static BallSpawner Instance;    // Static instance for global access

    private void Awake()
    {
        // Set the static instance (singleton pattern)
        Instance = this;
    }

    private void Start()
    {
        // Spawn the first ball when the game starts
        SpawnNewBall();
    }

    // Method to spawn a new ball at a position in front of the camera
    public void SpawnNewBall()
    {
        float distance = ballPrefab.GetComponent<BallControl>().followDistance;
        Vector3 spawnPos = playerCamera.position + playerCamera.forward * distance;
        Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    }

}
