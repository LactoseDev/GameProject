using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject nailPrefab;
    private Animator anim;

    public float nailThrowForce;
    public float shootCooldown;
    public bool cooldown;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

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
        anim.SetTrigger("nailThrowStraight");
        GameObject projectile = Instantiate(nailPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rBody = projectile.GetComponent<Rigidbody2D>();
        rBody.AddForce(shootPoint.up * nailThrowForce, ForceMode2D.Impulse);
    }

    // Cooldown Logic
    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        cooldown = false;
    }
}
