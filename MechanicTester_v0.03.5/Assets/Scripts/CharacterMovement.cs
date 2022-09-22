using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Stores the Rigidbody of the Character
    private Rigidbody2D rBody;
    private Animator anim;
    private CapsuleCollider2D capsColl2D;

    [SerializeField] private float moveSpeed;
    private float moveX = 0f;


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
        DirectionCheck();


        anim.SetBool("isRunning", moveX != 0);
    }

    // Update is called once for 50 frames
    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(moveX * moveSpeed, rBody.velocity.y);
    }

    protected void SetMoveX(float moveHorizontal)
    {
        moveX = moveHorizontal;
    }

    // Method to check what way the character is facing
    private void DirectionCheck()
    {
        if (moveX >= 0.1)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveX <= -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
