using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    PlayerController playerControllerScript;
    Vector3 spawnPos = new Vector3(25, 0.5f, 0);
    float startDelay = 2.0f;
    float repeatRate = 2.0f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle",
            startDelay, repeatRate);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        Debug.Log("spawn!");
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab,
                spawnPos,
                obstaclePrefab.transform.rotation);
        }
        else
        {
            CancelInvoke();
        }
    }
}
