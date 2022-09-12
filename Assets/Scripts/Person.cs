using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public abstract class Person : MonoBehaviour
{
    [Header("Rigibody")]
    [SerializeField] public Rigidbody2D _rb;

    [Header("Life")]
    [SerializeField] public float _lifeMax;
    [SerializeField] public float _lifeDeath;
    [HideInInspector] public float _life;

    [Header("Movement")]
    [HideInInspector] public Vector3 _direction;

    [Header("Speed")]
    [SerializeField] public float _speedWalk;
    [SerializeField] public float _speedRun;

    [Header("Animator")]
    [SerializeField] public Animator _animator;

    private void Start()
    {
        _life = _lifeMax;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + _direction * _speedWalk);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        _life = Mathf.Max(_life - _lifeDeath, 0);
        if (_life == 0)
        {
            _animator.SetBool("IsDeath", true);
        }
    }
}
