using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Person
{
    [Header("Health")]
    //[SerializeField] Slider _slider;

    /*[Header("Score")]
     * 
    [SerializeField] TextMeshPro _score;*/
    [Header("Input")]
    [SerializeField] InputActionReference _walk;
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _attack;

    [Header("Jump")]
    [SerializeField] float _jumpTime;
    [SerializeField] Vector3 _jumpHeight;

    [Header("Touch")]
    [SerializeField] float _protectionTime;

    float _oldLifeDeath;

    private void Start()
    {
       // _slider.value = _slider.maxValue = _lifeMax;

        _walk.action.started += WalkStarted;
        _walk.action.performed += WalkPerformed;
        _walk.action.canceled += WalkCanceled;

        _run.action.started += RunStarted;
        _run.action.performed += RunPerformed;
        _run.action.canceled += RunCanceled;

        //_jump.action.started += JumpStarted;

        //_jump.action.performed += JumpPerformed;
        //_jump.action.canceled += JumpCanceled;

        _attack.action.started += AttackStarted;
        _attack.action.performed += AttackPerformed;
        _attack.action.canceled += AttackCanceled;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        _oldLifeDeath = _lifeDeath;
        base.OnCollisionEnter2D(collision);
       // _slider.value = _life;
        while (Time.time < _protectionTime)
        {
            _lifeDeath = 0;
        }
        _lifeDeath = _oldLifeDeath;
    }

    private void WalkStarted(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector2>();
    }

    private void WalkPerformed(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector2>();
    }

    private void WalkCanceled(InputAction.CallbackContext obj)
    {
        _direction = Vector2.zero;
    }

    private void RunStarted(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsRun", true);
    }

    private void RunPerformed(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsRun", true);
        _animator.GetBool("IsRun");
    }

    private void RunCanceled(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsRun", false);
    }

    private void JumpStarted(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsJump", true);
    }

    private void JumpPerformed(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsJump", true);
    }

    private void JumpCanceled(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsJump", false);
    }

    private void AttackStarted(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsAttack", true);
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsAttack", true);
    }

    private void AttackCanceled(InputAction.CallbackContext obj)
    {
        _animator.SetBool("IsAttack", false);
    }
}