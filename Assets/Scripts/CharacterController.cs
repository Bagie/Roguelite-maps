using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rgdbdy2d;
    Vector2 movementVec;
    Animator animator;
    Weapon_Parent weapon_Parent;
    private Vector2 pointerInput;

    // [Tooltip("Health bar images")]
    [Header("Health bar images")]

    [SerializeField] Transform healtBarFront;
    [SerializeField] Transform healtBarBack;


    [Space]
    [Header("Character attributes")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int maxHealth = 100;
    public int currentHealth;  //debug

    [Space]
    [Header("Input controls")]
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private InputActionReference pointerPosition;


    private void Awake()
    {
        rgdbdy2d = GetComponent<Rigidbody2D>();
        movementVec = new Vector3();
        animator = GetComponent<Animator>();
        weapon_Parent = GetComponentInChildren<Weapon_Parent>();
    }

    void Start()
    {


        if (currentHealth == 0)      // pirma kart paleidziant, jei nenustatyta Hp - sulygina su max
        { currentHealth = maxHealth; }
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    void Update()

    {
        GettingInputs();
        HealtBarControl();
        HealthCheck();
        Animate();
    }

    private void HealthCheck()
    {
        if (currentHealth <= 0)
        { Die(); }
    }

    private void GettingInputs()
    {
        pointerInput = GetPointerInput();
        weapon_Parent.PointerPosition = pointerInput;
        movementVec = movement.action.ReadValue<Vector2>();
    }

    private void HealtBarControl()
    {
        float barState = (float)currentHealth;
        barState = Mathf.Clamp01(barState / maxHealth);
        healtBarFront.localScale = new Vector3(barState, 1, 1);
    }

    private void Die()
    {
        Debug.Log("Miriau");
    }


    private void PerformAttack(InputAction.CallbackContext obj)
    {
        weapon_Parent.AttackAllWeapons();
    }
    private void Animate()  //animacijos kontrol4
    {
        animator.SetFloat("Horizontal", movementVec.x);
        animator.SetFloat("Vertical", movementVec.y);
        animator.SetFloat("Speed", movementVec.sqrMagnitude);
    }

    private Vector2 GetPointerInput()  // kur pelyte
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate()
    {
        rgdbdy2d.velocity = movementVec * moveSpeed;
    }

    // --==PUBLIC==- //

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
    }

    public void HealthAdjustment(int _change)
    {
     currentHealth += _change;
    }



}
