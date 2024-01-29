using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setting")]
    public float moveSpeed;
    public float jumpForce;
    public float currentDistance;
    public float currentTime;

    public Animator doubleJump;
    public Transform respawn;

    public LayerMask layerGrounded;
    public LayerMask layerActiveCollider;

    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    private BoxCollider2D m_BoxCollider;
    private CoinManager m_CoinManager;
    private HeartManager m_HeartManager;

    private bool isDoubleJump;
    private bool isFalling;
    private bool isSpike;
    private bool isProtect;

    private Transform defPos;

    private void Awake()
    {
        respawn = GameObject.Find("Confiner").transform.Find("ReSpawn");
    }
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_CoinManager = GetComponent<CoinManager>();
        m_HeartManager = GetComponent<HeartManager>();

        defPos = transform;
        isFalling = false;
        InvokeRepeating("UpdateDistanceMoved", 1f, 1f);
    }

    private void Update()
    {
        if (isFalling)
        {
            isProtect = true;
            isDoubleJump = true;
            m_Animator.SetTrigger("hurt");
            transform.position = Vector2.MoveTowards(transform.position, respawn.position, 1f);
            StartCoroutine(IsFalling());
            StartCoroutine(IsProtect());
            return;
        }

        currentTime += Time.deltaTime;
        //currentDistance = Mathf.RoundToInt(currentTime * moveSpeed);
        //currentDistance += Mathf.RoundToInt(Time.deltaTime * moveSpeed);
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() || isDoubleJump)
            {
                if (!IsGrounded())
                {
                    doubleJump.SetTrigger("doubleJump");
                    isDoubleJump = false;
                }
                else
                {
                    isDoubleJump = true;
                }
                m_Rigidbody.velocity = Vector2.up * jumpForce;
                AudioManager.instance.PlaySFXJump();
            }
        }

        if (IsGrounded())
        {
            m_Animator.SetBool("isJumping", false);
        } else
        {
            m_Animator.SetBool("isJumping", true);
        }

    }

    IEnumerator IsProtect()
    {
        yield return new WaitForSeconds(5f);
        isProtect = false;
    }
    private void UpdateDistanceMoved()
    {
        if (isFalling) { return; }
        currentDistance += moveSpeed * 2;
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_BoxCollider.bounds.center, m_BoxCollider.bounds.size, 0f, Vector2.down, 0.1f, layerGrounded);
    }

    public bool IsActiveCollider()
    {
        return Physics2D.BoxCast(m_BoxCollider.bounds.center, m_BoxCollider.bounds.size, 0f, Vector2.down, 0.1f, layerActiveCollider);
    }

    public void TakeDamage()
    {
        m_Animator.SetTrigger("hurt");
        if (isSpike) return;
        if (isProtect) return;
        m_HeartManager.UpdateHeart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            m_CoinManager.UpdateCoin(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            collision.gameObject.GetComponent<ChestManager>().OpenChest();
        }
        if (collision.gameObject.CompareTag("Falling"))
        {
            isFalling = true;
            TakeDamage();
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage();
            isSpike = true;
            StartCoroutine(IsSpike());
            //m_Rigidbody.velocity = new Vector2(respawn.position.x, m_Rigidbody.velocity.y);
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(respawn.position.x,transform.position.y), 5f);

        }
    }

    IEnumerator IsSpike()
    {
        yield return new WaitForSeconds(2f);
        isSpike = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().DieAndRemove();
            TakeDamage();
        }
        if (collision.gameObject.CompareTag("Falling"))
        {
            isFalling = true;
            TakeDamage();
        }
    }

    IEnumerator IsFalling()
    {
        yield return new WaitForSeconds(2f);
        isFalling = false;
    }

}
