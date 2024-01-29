using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public List<GameObject> spawnPositions = new List<GameObject>();
    public GameObject coinPrefabs;

    private void Awake()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        foreach (var childTransform in childTransforms)
        {
            if (childTransform.name == "SpawnPos")
            {
                spawnPositions.Add(childTransform.gameObject);
            }
        }
    }

    private void Start()
    {
        int value = Random.Range(3, spawnPositions.Count);
        if (value > 0)
        {
            for (int i = 0; i < value; i++)
            {
                CreateCoin(spawnPositions[i].transform);
            }
        }
    }

    private void CreateCoin(Transform pos)
    {
        GameObject newCoin = Instantiate(coinPrefabs,transform);
        newCoin.transform.position = pos.position;
        newCoin.name = "Coin";
    }
}
