using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public TextMeshProUGUI fillHeart;
    public int maxHeart = 3;

    private int currentHeart;

    private void Start()
    {
        currentHeart = maxHeart;
    }

    private void Update()
    {
        
    }

    public void UpdateHeart()
    {
        currentHeart--;
        if (currentHeart < 0)
        {
            Die();
        } else
        {
            fillHeart.text = currentHeart.ToString();
        }
    }
    private void Die()
    {
        GameManager.instance.EndGame();
        Destroy(gameObject);
    }
}
