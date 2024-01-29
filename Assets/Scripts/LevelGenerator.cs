using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float DistanceSpawn;
    public Transform leverPartStart;
    public Transform parent;
    public List<Transform> levelParts = new List<Transform>();
    
    private PlayerController playerController;

    public Vector3 lastEndPosition;
    public Transform lastSpawnLevePart;

    private void Awake()
    {
        lastEndPosition = leverPartStart.Find("EndPosition").position;
        int startSpawn = 5;
        for (int i = 0; i < startSpawn; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (playerController == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        if (playerController == null) return;
        lastEndPosition = lastSpawnLevePart.transform.Find("EndPosition").transform.position;
        if (Vector2.Distance(playerController.transform.position, lastEndPosition) < DistanceSpawn)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform randomLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLeverPart(randomLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        lastSpawnLevePart = lastLevelPartTransform;
    }

    private Transform SpawnLeverPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelPartTransform.transform.parent = parent;
        return levelPartTransform;
    }
}
