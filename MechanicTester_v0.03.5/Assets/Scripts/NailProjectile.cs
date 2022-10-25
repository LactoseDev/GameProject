using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    private Rigidbody2D rBody;
    public GameObject nailProjectile;
    private Vector2 savedPosition;

    public GameObject hitEffect;
    public GameObject wallNailEffect;

    public int damageValue;
    private bool isPinned;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //nailPlatform = 
    }

    void Update()
    {
        if (isPinned == true)
        {
            // Stores the nails final position
            savedPosition = nailProjectile.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPinned == false)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().HandleDamage(damageValue);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //GameObject effect = Instantiate(wallNailEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 1f);
            isPinned = true;
            // stores the old gravity on the nail (in case it needs to be changed)
            float originalGravity = rBody.gravityScale;
            rBody.gravityScale = 0f;
            // stops the nails current movement
            rBody.velocity = Vector2.zero;
            // Freezes the nails constrains so it can't move
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;
            // Stops the transforms of the perception range and the platform.
            // Platform
            transform.GetChild(0).gameObject.transform.rotation = Quaternion.identity;
            transform.GetChild(0).gameObject.SetActive(true);
            // Perception Range
            transform.GetChild(1).gameObject.transform.rotation = Quaternion.identity;
            transform.GetChild(1).gameObject.SetActive(true);
        }



    }

}
