using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    Rigidbody2D rgdbdy2d;
    Vector3 movementVec3;
    Animator animator;

    [SerializeField] float moveSpeed = 3f;
    private void Awake()
    {
        rgdbdy2d = GetComponent<Rigidbody2D>();
        movementVec3 = new Vector3();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        movementVec3.x = Input.GetAxisRaw("Horizontal");
        movementVec3.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movementVec3.x);
        animator.SetFloat("Vertical", movementVec3.y);
        animator.SetFloat("Speed", movementVec3.sqrMagnitude);
    }

    private void FixedUpdate()
    {

        rgdbdy2d.velocity = movementVec3 * moveSpeed ;
    }

}
