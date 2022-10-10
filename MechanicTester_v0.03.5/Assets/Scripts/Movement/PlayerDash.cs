using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    /*// Grabbing components from player
    private Animator anim;
    private Rigidbody2D rBody;

    // Allows for a deactivatable dash
    [SerializeField] private bool canDash;

    // Dash Variables
    [SerializeField] private float dashForce;
    //public float dashTimer = 1f;
    //public float dashRate = 4f;
    
    // Dash Cooldown
    //private float dashCooldown = 0.1f;
    //private bool isDashing;
    //private bool hasGrounded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash == true)
        {
            InputCheck();

            //GroundedCheck();
        }
    }

    //------------- CUTSOM FUNCTIONS -------------------

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift was pressed!");
            Dash();
        }
    }

    void GroundedCheck()
    {
        this.GetComponent<PlayerJump>().IsGrounded(grounded);
    }

    void DashCheck()
    {
        if (hasGrounded == true && isDashing == false)
            Dash();
    }

    private void Dash()
    {
        rBody.velocity = new Vector2(dashForce, rBody.velocity.y);
        Debug.Log("Dashed!");
        anim.SetTrigger("dash");
        //StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown()
    {
        isDashing = true;
        hasGrounded = false;
        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }*/

}
