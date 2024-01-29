using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCollider : MonoBehaviour
{
    private EdgeCollider2D Edge;
    private PlayerController controller;

    private void Awake()
    {
        Edge = GetComponent<EdgeCollider2D>();
    }
    private void Update()
    {
        if (controller == null && GameObject.Find("Player") != null)
        {
            controller = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        if (controller == null) return;

        if (controller.IsActiveCollider())
        {
            Edge.enabled = true;
        } else
        {
            Edge.enabled = false;
        }
    }
}
