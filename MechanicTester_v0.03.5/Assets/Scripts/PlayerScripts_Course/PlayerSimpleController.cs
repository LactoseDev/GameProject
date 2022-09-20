using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleController : MonoBehaviour
{
    // Stores reference to Rigidbody
    private Rigidbody2D rBody;
    private Animator anim;
    private CapsuleCollider2D capsColl2D;
    
    // Stores Layer Masks
    [SerializeField] private LayerMask groundLayer;

    // Stores Movement Speed
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 0f;
    private float moveX = 0f;

    // Coyote Time Variables
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsColl2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Input Check
        moveX = Input.GetAxis("Horizontal");

        // Flips character sprite depending on which way you're facing
        if (moveX >= 0.1)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveX <= -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Coyote Time Logic
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }


        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0)
        {
            Jump();
        }

        // Variable Jump Height
        if (Input.GetButtonUp("Jump") && rBody.velocity.y > 0)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }

        // Falling animtion (Not Working?)
        if (rBody.velocity.y <= -0.1)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }


        // SET ANIMATIONS
        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
        //       MOVEMENT CALCULATIONS
        // Horizontal Movement
        rBody.velocity = new Vector2(moveX * moveSpeed, rBody.velocity.y);
    }

    private void Jump()
    {

        rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        //anim.SetTrigger("Jump");
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsColl2D.bounds.center, capsColl2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
