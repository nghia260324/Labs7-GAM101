using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Setting")]
    public float moveSpeed;
    public int maxHealth;

    public EffectManager effectManager;

    [Header("Effects")]
    public string beforeDeath = "fire-1";

    private int currentHealth;

    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    //private PlayerController playerController;
    private CircleCollider2D m_CircleCollider;

    private void Start()
    {
        m_CircleCollider = GetComponent<CircleCollider2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        effectManager = GetComponent<EffectManager>();
        currentHealth = maxHealth;
    }
/*    private void Update()
    {
        if(playerController == null)
        {
            if (GameObject.Find("Player") != null)
            {
                playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            } else
            {
                playerController = null;
            }
        }

    }*/

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            DieAndRemove();
        } else
        {
            m_Animator.SetTrigger("hit");
            effectManager.EffectHitEnemy();
        }
    }

    public void DieAndRemove()
    {
        effectManager.EffectBeforeDeath();
        StartCoroutine(HideBody());
        StartCoroutine(Die());
        ArmorManager.instance.UpdateArmor(1);
        effectManager.EffectDropArmor(transform);
        m_Rigidbody.gravityScale = 0;
        Destroy(m_CircleCollider);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    IEnumerator HideBody()
    {
        yield return new WaitForSeconds(0.35f);
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer.gameObject.tag != "Effect")
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
