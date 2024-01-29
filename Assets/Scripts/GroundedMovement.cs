using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
