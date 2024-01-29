using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingShapeManager : MonoBehaviour
{
    CinemachineConfiner Confiner;

    public void Start()
    {
        Confiner = GetComponent<CinemachineConfiner>();
        GameObject levelObject = GameObject.Find("Confiner");
        PolygonCollider2D polygonCollider = levelObject.GetComponent<PolygonCollider2D>();
        Confiner.m_BoundingShape2D = polygonCollider;
    }
}
