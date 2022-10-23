using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    private Rigidbody2D rBody;
    private GameObject nailPlatform;

    public GameObject hitEffect;
    public GameObject wallNailEffect;

    public int damageValue;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //nailPlatform = 
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //GameObject effect = Instantiate(wallNailEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 1f);
            float originalGravity = rBody.gravityScale;
            rBody.gravityScale = 0f;
            rBody.velocity = Vector2.zero;
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.GetChild(0).gameObject.transform.rotation = Quaternion.identity;

            //nailPlatform.SetActive(true);

            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
