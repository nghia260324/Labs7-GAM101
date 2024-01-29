using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityManager : MonoBehaviour
{
    public Transform content;
    public GameObject itemQuantityPrefabs;

    public List<GameObject> items = new List<GameObject>();

    public void UpdateItem(int current,int max)
    {
        for (int i = 0; i < max; i++)
        {
            if (i > current - 1)
            {
                items[i].GetComponent<Image>().enabled = false;
            } else
            {
                items[i].GetComponent<Image>().enabled = true;
            }
        }
    }

    public void ResetQuantity(int quantity)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < quantity; i++)
        {
            GameObject newItem = Instantiate(itemQuantityPrefabs, content.transform);
            newItem.name = "ItemQuantity";
            items.Add(newItem);
        }
    }
}
