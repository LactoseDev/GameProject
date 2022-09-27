using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform enemyAim;
    public GameObject projectilePrefab;
    public EnemyPerception enemyPerception;

    public float projectileForce;
    public float shootCooldown;
    public bool cooldown;

    // For look flipping
    public GameObject player;
    private bool flipped;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is in range fire a projectile after waiting cooldown
        if (enemyPerception.playerInRange == true && cooldown == false)
        {
            flipped = player.transform.position.x < transform.position.x;
            spriteRenderer.flipX = flipped;

            if (cooldown == false)
            {
                Shoot();
                StartCoroutine("Cooldown");
            }

        }

    }

    // Shooting Logic
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, enemyAim.position, enemyAim.rotation);
        Rigidbody2D rBody = projectile.GetComponent<Rigidbody2D>();
        rBody.AddForce(enemyAim.up * projectileForce, ForceMode2D.Impulse);
    }

    // Sets up cooldowns
    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        cooldown = false;
    }

}
