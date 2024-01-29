using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<GameObject> tables = new List<GameObject>();
    private int currentSelection = -1;

    private void Awake()
    {
        Selection(0);
    }
    public void Selection(int index)
    {
        if (currentSelection == index) { return; }
        currentSelection = index;
        for(int i = 0; i < tables.Count; i++)
        {
            if (i == index)
            {
                tables[i].SetActive(true);
            } else
            {
                tables[i].SetActive(false);
            }
        }
    }
}
