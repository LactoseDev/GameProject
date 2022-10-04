using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Animator anim;

    // Stagger Variables
    public float staggerTime;
    public static bool frozen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);
        anim.SetTrigger("hit");

        // Death Logic
        if (currentHealth <= 0)
        {
            Debug.Log("Dead Enemy");

            // Death Animation
            anim.SetBool("isDead", true);

            // Increase Stagger Time for Death Animation
            staggerTime = 2f;

            // Destroy Enemy
            Destroy(gameObject, 0.6f);
        }

        // Starts Stagger
        StartCoroutine(Stagger());
    }

    // Handles Stagger
    public IEnumerator Stagger()
    {
        frozen = true;
        yield return new WaitForSeconds(staggerTime);
        frozen = false;
    }
}
