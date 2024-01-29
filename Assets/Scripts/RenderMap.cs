using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMap : MonoBehaviour
{
    public Transform grounded;
    public PlayerController controller;
    public float distanceSpawn;
    public GameObject mapStart;
    public List<GameObject> mapPrefabs = new List<GameObject>();

    private GameObject lastMap;

    private void Awake()
    {
        lastMap = mapStart;
        SpawnMap();
    }

    private void Update()
    {
        if (Vector2.Distance(controller.transform.position, lastMap.transform.position) < distanceSpawn)
        {
            SpawnMap();
        }
    }
    private void SpawnMap()
    {
        float sizeOfA = 0f;

        Collider2D colliderA = lastMap.GetComponent<Collider2D>();
        if (colliderA != null)
        {
            sizeOfA = colliderA.bounds.size.x;
        }
        else
        {
            Renderer rendererA = lastMap.GetComponent<Renderer>();
            if (rendererA != null)
            {
                sizeOfA = rendererA.bounds.size.x;
            }
        }

        Vector3 positionOfA = lastMap.transform.position;


        GameObject newMap = Instantiate(mapPrefabs[Random.Range(0,mapPrefabs.Count)]);

        float offset = sizeOfA / 2f;
        Vector3 newPositionForB = new Vector3(positionOfA.x + offset, newMap.transform.position.y, newMap.transform.position.z);
        newMap.transform.position = newPositionForB;
        newMap.transform.parent = grounded.transform;

    }
}
