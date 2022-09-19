using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleController : MonoBehaviour
{
    // Stores reference to Rigidbody
    private Rigidbody2D rBody;
    private Animator anim;

    // Stores Movement Speed
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private bool canJump;
    [SerializeField] private int jumpCount;
    [SerializeField] private int jumpCountMax = 2;
    private float moveX = 0f;

    // Variables for checking Players State
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        //JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // SET ANIMATIONS
        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGrounded", isGrounded != false);
    }

    private void FixedUpdate()
    {
        //       MOVEMENT CALCULATIONS
        // Horizontal Movement
        rBody.velocity = new Vector2(moveX * moveSpeed, rBody.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            jumpCount += 1;

            if (canJump == true && (jumpCount <= jumpCountMax))
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
                isGrounded = false;
            }
            else
            {
                isGrounded = false;
                //canJump = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }


}
