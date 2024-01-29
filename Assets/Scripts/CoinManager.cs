using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI fillCoin;

    public int currentCoint;

    private void Awake()
    {
        instance = this;
        UpdateCoin(0);
    }

    public void UpdateCoin(int quantity)
    {
        currentCoint += quantity;
        fillCoin.text = currentCoint.ToString();
    }
}
