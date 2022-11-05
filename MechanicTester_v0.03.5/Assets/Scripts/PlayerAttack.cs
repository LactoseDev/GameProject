using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public Transform attackPoint;

    public int attackDamage = 1;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    private float attackCooldown;
    public LayerMask enemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("attack01");

                //Attack Sound
                FindObjectOfType<AudioManager>().Play("PlayerAttack");

                // Attack Here
                Attack();

                // trigger attack cooldown
                attackCooldown = Time.time + 1 / attackRate;
            }

        }
    }

    void Attack()
    {
        // Play attack animation
        anim.SetTrigger("attack01");

        // Detect enemies within range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage Enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            // Lower Enemy Health
            Debug.Log("You Hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().HandleDamage(attackDamage);
        }
    }


}
