using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpn_blast : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] int damage = 1;
    CapsuleCollider2D capsuleCollider;
    Vector3 pointerInput;
    Animator animator;
    private bool attackStop;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>(); 
        capsuleCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D _other)
    {
        //Debug.Log(_other.name + "atakuoju bet be tag  TRIGGER");
        if (_other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(_other + "atakuoju");
            _other.GetComponent<Enemy>().DamageDealt(damage);
        }

    }
 /*   private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision + "atakuoju bet be tag");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision + "atakuoju");
            //Attack(other);
        }
    }*/

    public void Attack()
    {
       
        if (attackStop)
        { return; }
        capsuleCollider.enabled = true;
        animator.SetTrigger("Attack");
        attackStop = true;
        
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(cooldown);
        capsuleCollider.enabled = false;
        attackStop = false;
    }
}