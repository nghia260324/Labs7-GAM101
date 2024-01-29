using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public GameObject chestPrefabs;
    public Transform chestPos;

    private void Start()
    {
        int value = Random.Range(0, 2);
        if (value == 1)
        {
            CreateChest();
        }
    }

    private void CreateChest()
    {
        GameObject newChest = Instantiate(chestPrefabs,chestPos.position,Quaternion.identity);
        newChest.transform.parent = transform;
        newChest.name = "Chest";
        newChest.GetComponent<ChestManager>().parent = transform;
    }
}
