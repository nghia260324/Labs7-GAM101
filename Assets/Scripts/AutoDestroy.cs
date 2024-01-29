using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float distance;
    private PlayerController controller;

    private void Update()
    {
        if (controller == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        } else
        {
            if (controller != null && (transform.position - controller.transform.position).x < -distance)
            {
                Destroy(gameObject);
            }
        }
    }
}
