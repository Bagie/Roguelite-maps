using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Reikt? array su skirtingom attackom prid?ti
    [SerializeField] Transform targetPlayer; //judejimui
    GameObject targetGameObject;   //atakai
    [SerializeField] float speed;
    [SerializeField] float attackRate;
    [SerializeField] int enemyMaxHealth = 50;
    [SerializeField] int enemyCurrentHealth;  //debug public
    [SerializeField] int rawDamage = 1;
    [SerializeField] Transform enemyHealtBarFront;
    [SerializeField] bool useNavMesh = true;
    Rigidbody2D rgdBd2d;
    Animator animator;
    bool canFallow = true;
    NavMeshAgent agent;



    // Start is called before the first frame update
    private void Awake()
    {

        enemyCurrentHealth = enemyMaxHealth;
        animator = GetComponent<Animator>();
        rgdBd2d = GetComponent<Rigidbody2D>();

        FindingPlayer();

        SettingUpNavMesh();


    }

    private void FindingPlayer()
    {
        if (targetPlayer == null)
        {
            GameObject _targetObject = GameObject.FindGameObjectWithTag("Player");   //reik pakeisti, o jei 2 zaidejai ?
            targetPlayer = _targetObject.transform;
        }
        targetGameObject = targetPlayer.gameObject;
    }

    private void SettingUpNavMesh()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (enemyCurrentHealth <= 0)
        { Death(); }

        EnemyHealtBarControl();
        Animate();

    }

    private void FixedUpdate()  // Veik?jo paieška ir jud?jimas .  Praverst? geresnis b?das, jei MP nor??iau ir galimyb?, jei jam nereik jud?ti iki pat veik?jo (limiteris) 
    {
       if (useNavMesh == true)
        {
            NavMeshMovement();
        }
       else
        {
            Movement();
        }
        
    }

    private void NavMeshMovement()
    {
        agent.speed = speed;
        agent.SetDestination(targetGameObject.transform.position);
    }

    private void EnemyHealtBarControl()
    {
        float barState = (float)enemyCurrentHealth;
        barState = Mathf.Clamp01(barState / enemyMaxHealth);
        enemyHealtBarFront.localScale = new Vector3(barState/2, 1, 1);
    }

    private void Death()
    {
        Debug.Log("Mire");
        Destroy(gameObject);

    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", rgdBd2d.velocity.normalized.x);
        animator.SetFloat("Vertical", rgdBd2d.velocity.normalized.y);
        animator.SetFloat("Speed", rgdBd2d.velocity.sqrMagnitude);
    }

  

    private void Movement()
    {
        if (canFallow == true)
        {
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            rgdBd2d.velocity = direction * speed;
        }
        else
            rgdBd2d.velocity = Vector3.left * speed;

       
    }



    private void OnCollisionStay2D(Collision2D _collision)  //Animacija gal ?
    {
        if (_collision.gameObject == targetGameObject) 
        {
            Attack(_collision.gameObject);
        }
        else if (_collision.gameObject.tag == "Obstacle")
        {
            canFallow = false;
        }
        else
        {
            canFallow = true;
        }
       
    }

    private void Attack(GameObject _target)
    {
        if (_target != null)
        {
            _target.GetComponent<CharacterController>().TakeDamage(rawDamage);
        }       
    }


    // --==PUBLIC==- //
    public void DamageDealt(int _damage) //kiek gavo damage
    {
        enemyCurrentHealth -= _damage;
        
    }
    
}
