using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject playerPrefabs;
    public GameObject spawnPos;

    private void Awake()
    {
        instance = this;
    }
    public void CreatePlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefabs,spawnPos.transform.position,Quaternion.identity);
        newPlayer.name = "Player";
    }

}
