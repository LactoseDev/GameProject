using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    [SerializeField] private int damageValue;
    [SerializeField] private float bounceForce;

    // Logic for jump attack
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Logic for jumping on breakables
        if (collision.gameObject.CompareTag("Breakable"))
        {
            // Deal damage to object
            collision.gameObject.GetComponent<Breakable>().HandleDamage(damageValue);
            // Bounce
            this.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
        }

        // Logic for jumping on enemies
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Deal damage to enemy

            // Bounce
        }
    }


}
