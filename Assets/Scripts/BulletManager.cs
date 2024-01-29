using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletManager : MonoBehaviour
{
    [Header("Setting")]
    public int maxQuantity;
    public float attackInterval;
    public float bulletForce;
    public float timeReload;

    public GameObject firePos;
    public GameObject bulletPrefabs;
    public QuantityManager quantityManager;

    private Animator m_Animator;

    private bool isReload;

    private float currentAttackInterval;
    private float currentTimeReload;
    public int currentQuantity;


    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        currentQuantity = maxQuantity;
        currentTimeReload = timeReload;
        quantityManager.ResetQuantity(maxQuantity);
        isReload = true;
    }

    private void Update()
    {
        currentAttackInterval += Time.deltaTime;
        currentTimeReload += Time.deltaTime;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButton(0) && currentAttackInterval > attackInterval && currentQuantity > 0)
        {
            Attack();
        }

        if (!Input.GetMouseButton(0) && isReload && currentQuantity < maxQuantity)
        {
            StartCoroutine(Reload());
            isReload = false;
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(timeReload);
        currentQuantity++;
        currentTimeReload = 0;
        quantityManager.UpdateItem(currentQuantity, maxQuantity);
        isReload = true;
    }

    private void Attack()
    {
        m_Animator.SetTrigger("attack");
        currentAttackInterval = 0;
        Shoot();
    }

    private void Shoot()
    {
        CreateBullet();
        //AudioManager.instance.Play
    }

    private void CreateBullet()
    {
        currentQuantity--;
        GameObject newBullet = Instantiate(bulletPrefabs, firePos.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletForce, ForceMode2D.Impulse);
        newBullet.name = "Bullet";
        quantityManager.UpdateItem(currentQuantity, maxQuantity);
        Destroy(newBullet, 0.8f);
    }

}
