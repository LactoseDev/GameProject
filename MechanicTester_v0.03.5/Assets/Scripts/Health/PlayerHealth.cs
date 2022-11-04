using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{ 
    public GameObject checkpoint;
    private Animator anim;
    private Transform spawnPoint;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);
        anim.SetTrigger("hit");
        Debug.Log("HitAnimation");

        // Death Logic
        if (currentHealth <= 0)
        {
            this.gameObject.transform.position = spawnPoint.transform.position;
            currentHealth = maxHealth;

            // Death Animation

            // Screen Fade

            // Sounds

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            spawnPoint = other.GetComponentInChildren<Transform>();
        }
    }

}
