using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    private Rigidbody2D rBody;

    public GameObject hitEffect;
    public GameObject wallNailEffect;

    public int damageValue;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().HandleDamage(damageValue);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //GameObject effect = Instantiate(wallNailEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 1f);
            float originalGravity = rBody.gravityScale;
            rBody.gravityScale = 0f;
            rBody.velocity = Vector2.zero;
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }

}
