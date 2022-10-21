using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    public GameObject enemyHitEffect;
    public GameObject wallNailEffect;

    public int damageValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyHealth>().HandleDamage(damageValue);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }

        /*if (collision.gameObject.CompareTag("Wall"))
        {
            //HitWall();
        }*/
    }

    /*private void HitWall()
    {
        GameObject effect = Instantiate(wallNailEffect, transform.position, Quaternion.identity);
    }*/

}
