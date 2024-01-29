using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("Effect")]
    public string effectHitEnemy = "hit-1";
    public string effectHitChest = "hit-1";
    public string effectBeforeDeath = "fire-1";

    public GameObject VFX_CoinMagnetFX;
    public GameObject VFX_ArmorMagnetFX;

    public GameObject effectPrefabs;

    public void EffectHitEnemy()
    {
        CreateEffect(effectHitEnemy);
    }
    public void EffectHitChest()
    {
        CreateEffect(effectHitChest);
    }
    public void EffectBeforeDeath()
    {
        CreateEffect(effectBeforeDeath);
    }
    public void EffectDropCoin(Transform parent)
    {
        GameObject newVFX = Instantiate(VFX_CoinMagnetFX,transform.position,Quaternion.identity);
        newVFX.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        newVFX.transform.localScale = new Vector3(1, 1, 1);
        newVFX.transform.parent = parent;
    }

    public void EffectDropArmor(Transform parent)
    {
        GameObject newVFX = Instantiate(VFX_ArmorMagnetFX, transform.position, Quaternion.identity);
        newVFX.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        newVFX.transform.localScale = new Vector3(1, 1, 1);
        newVFX.transform.parent = parent;
    }

    private void CreateEffect(string effect)
    {
        GameObject newEffect = Instantiate(effectPrefabs,transform.position,Quaternion.identity);
        newEffect.transform.parent = transform;
        newEffect.GetComponent<EffectController>().PlayEffect(effect);
        Destroy(newEffect, 1);
    }
}
