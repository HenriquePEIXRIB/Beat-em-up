using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Person
{
    [Header("HealthUI")]
    [SerializeField] Slider _slider;

    [Header("Score")]
    [SerializeField] TextMeshPro _score;

    [Header("Run")]
    [SerializeField] InputActionReference _run;
    [SerializeField] float _speedRun;

    [Header("Touch")]
    [SerializeField] float _waitProtection;

    [Header("Jump")]
    [SerializeField] InputActionReference _jump;
    [SerializeField] float _jumpTime;
    [SerializeField] Vector3 _jumpHeight;

    float _oldLifeDeath;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        _oldLifeDeath = _lifeDeath;
        base.OnCollisionEnter2D(collision);
        while (Time.time < _waitProtection)
        {
            _lifeDeath = 0;
        }
        _lifeDeath = _oldLifeDeath;
    }
}
