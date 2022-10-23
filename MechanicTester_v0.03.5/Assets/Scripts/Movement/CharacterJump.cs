using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterJump : MonoBehaviour
{
    // Store Ref to Core Components
    protected Rigidbody2D rBody;
    private Animator anim;
    private CapsuleCollider2D capsColl2D;

    // Layer Masks
    [SerializeField] private LayerMask groundLayer;

    // Stores Movement Variables
    [SerializeField] private float jumpForce;
    protected Action onGrounded;
    protected Action onJump;

    // Coyote Time & Jump Buffer
    protected bool doJump;
    [SerializeField] private float coyoteTime;
    private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime;
    private float jumpBufferCounter;

    // Jump Cooldown
    private bool isJumping;
    private float jumpCoolDown = 0.1f;

    //-----------------------------------------------------------------

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsColl2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Coyote Time Logic
        CoyoteTimeCheck();

        // Jump Buffer Logic
        JumpBufferCheck();

        // Jump Check
        JumpCheck();

        doJump = false;

        anim.SetBool("isGrounded", IsGrounded());
        anim.SetBool("isFalling", IsFalling());
    }

    // checks to see if jumping
    private void JumpCheck()
    {
        if (!doJump || isJumping)
            return;

        if (!(jumpBufferCounter > 0) && !(coyoteTime > 0))
            return;

        ApplyJumpForce();
    }

    // actually jumps
    private void ApplyJumpForce()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        StartCoroutine(JumpCoolDown());
        onJump?.Invoke();
    }

    // is the cooldown between jumps
    private IEnumerator JumpCoolDown()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpCoolDown);
        isJumping = false;
    }

    // gives the player coyote time when jumping
    private void CoyoteTimeCheck()
    {
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    // Checks if falling, if so jump buffer counts
    private void JumpBufferCheck()
    {
        if (doJump && IsFalling())
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    // Checks to see if isFalling
    private bool IsFalling() => rBody.velocity.y <= -0.5f;

    // Allows for Jump Input
    protected void DoJump() => doJump = true;


    // Uses a raycast to check if grounded
    protected virtual bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsColl2D.bounds.center, capsColl2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        bool grounded = raycastHit.collider != null;

        if (grounded)
        {
            if (!isJumping)
            {
                onGrounded?.Invoke();
            }
            jumpBufferCounter = jumpBufferTime;
        }

        return grounded;
    }

    /*void OnColliderEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NailPlatform"))
        {
            anim.SetTrigger("onNailPlatform");
        }
    }*/

}
