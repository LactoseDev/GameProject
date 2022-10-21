using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform playerAim;
    public GameObject nailPrefab;

    public float nailThrowForce;
    public float shootCooldown;
    public bool cooldown;

    // Update is called once per frame
    void Update()
    {
        if (cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shoot();
                StartCoroutine(Cooldown());
            }
        }
    }

    // Shooting Logic
    private void Shoot()
    {
        GameObject projectile = Instantiate(nailPrefab, playerAim.position, playerAim.rotation);
        Rigidbody2D rBody = projectile.GetComponent<Rigidbody2D>();
        rBody.AddForce(playerAim.up * nailThrowForce, ForceMode2D.Impulse);
    }

    // Cooldown Logic
    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        cooldown = false;
    }
}
