using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        Destroy(gameObject, 10f);
    }
    public void PlayEffect(string parameters)
    {
        m_Animator.SetTrigger(parameters);
    }
    public void PlayerBoolEffect(string parameters)
    {
        m_Animator.SetTrigger(parameters);
    }
}
