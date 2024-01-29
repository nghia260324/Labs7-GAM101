using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{
    public static ArmorManager instance;

    public int maxArmor = 15;
    public QuantityManager quantityManager;

    private EffectManager effectManager;

    private int currentArmor = 0;

    private void Awake()
    {
        effectManager = GetComponent<EffectManager>();
        instance = this;
        quantityManager.ResetQuantity(maxArmor);
        quantityManager.UpdateItem(currentArmor, maxArmor);
    }

    private void Update()
    {
        if (currentArmor == maxArmor)
        {
            currentArmor = 0;
            quantityManager.UpdateItem(currentArmor, maxArmor);
        }
    }

    public void UpdateArmor(int value)
    {
        currentArmor += value;
        if (currentArmor <= maxArmor)
        {
            quantityManager.UpdateItem(currentArmor, maxArmor);
        }
        else
        {

        }
    }
}
