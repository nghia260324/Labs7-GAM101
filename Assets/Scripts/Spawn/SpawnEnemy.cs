using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public Transform spawnPos;

    private void Start()
    {
        int randomEnemy = Random.Range(0,enemyPrefabs.Count);
        CreateEnemy(enemyPrefabs[randomEnemy]);
    }

    private void CreateEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy,transform);
        newEnemy.transform.position = spawnPos.position;
        newEnemy.name = "Enemy";
    }

}
