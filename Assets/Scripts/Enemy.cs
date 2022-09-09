using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Person
{
    [Header("Detection")]
    [SerializeField] float _detectionDistance;
    [SerializeField] float _detectionTime;

    //[Header("Bonus Score")]
    //[SerializeField] MusicalObject[] _musicalObjects;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        _animator.SetBool("IsAttack", false);
        /*foreach (var item in _musicalObjects)
        {
            item.SetActive(true);
        }*/
        GameObject.Destroy(gameObject);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isWalk = (collision.attachedRigidbody.position.x - gameObject.transform.position.x) > _detectionDistance;
        _animator.SetBool("IsWalk", isWalk);
        if (isWalk == false && Time.time >= _detectionTime)
        {
            _animator.SetBool("IsAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("IsWalk", false);
    }


}
