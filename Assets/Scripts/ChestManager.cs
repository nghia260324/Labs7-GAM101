using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Sprite openChest;

    public int maxHealth;
    public int quantity;
    [HideInInspector]
    public Transform parent;

    private int currentHealth;

    private EffectManager m_EffectManager;
    private BoxCollider2D m_BoxCollider;

    private void Start()
    {
        currentHealth = maxHealth;
        m_EffectManager = GetComponent<EffectManager>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }


    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = openChest;
            m_BoxCollider.enabled = false;
            m_EffectManager.EffectDropCoin(parent);
            CoinManager.instance.UpdateCoin(quantity);
            StartCoroutine(DestroyChest());
        } else
        {
            m_EffectManager.EffectHitChest();
        }
    }
    IEnumerator DestroyChest()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void OpenChest()
    {
        currentHealth = 0;
        TakeDamage();
    }
}
