using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class Person : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float _lifeMax;
    [SerializeField] public float _lifeDeath;

    [Header("Walk")]
    [SerializeField] public InputActionReference _walk;
    [SerializeField] public float _speedWalk;

    [Header("Attack")]
    [SerializeField] public InputActionReference _attack;

    [Header("Animator")]
    [SerializeField] public Animator _animator;

    float _life;

    private void Start()
    {
        _life = _lifeMax;

        _walk.action.started += WalkStarted;
        _walk.action.performed += WalkPerformed;
        _walk.action.canceled += WalkCanceled;

        _attack.action.started += AttackStarted;
        _attack.action.performed += AttackPerformed;
        _attack.action.canceled += AttackCanceled;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        _life = Mathf.Max(_life - _lifeDeath, 0);
        if (_life == 0)
        {
            _animator.SetBool("IsDeath", true);
        }

    }

    private void WalkStarted(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void WalkPerformed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void WalkCanceled(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void AttackStarted(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void AttackCanceled(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
}
