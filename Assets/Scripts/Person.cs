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
    [SerializeField] protected Rigidbody2D _rb;

    [Header("Life")]
    [SerializeField] protected float _lifeMax;
    [SerializeField] protected float _lifeDeath;
    [HideInInspector] protected float _life;

    [Header("Movement")]
    [HideInInspector] protected Vector3 _direction;

    [Header("Speed")]
    [SerializeField] protected float _speedWalk;
    [SerializeField] protected float _speedRun;

    [Header("Animator")]
    [SerializeField] protected Animator _animator;

    public float Life
    {
        get
        {
            return _life;
        }
    }

    private void Start()
    {
        _life = _lifeMax;
    }

    private void FixedUpdate()
    {
        float moveSpeed = _speedWalk;
        

        if (_animator.GetBool("IsRun"))
        {
            moveSpeed *= _speedRun;
        }
        else
        {
            moveSpeed *= 1f;
        }

        //moveSpeed *= (_animator.GetBool("IsRun")) ? _speedRun : 1f;


        _animator.SetBool("IsWalk", _direction.magnitude > 0.1f);
        _rb.MovePosition(transform.position + (_direction * Time.fixedDeltaTime * moveSpeed));
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
