using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    /*private Animator anim;
    private Rigidbody2D rBody;
    private float horizontalDirection;
    private float verticalDirection;
    private CharacterMovement characterMovement;

    // Dash Variables
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashLength = 0.3f;
    [SerializeField] private float dashBufferLength = 0.1f;
    private float dashBufferCounter;
    private bool isDashing;
    private bool hasDashed;
    private bool canDash => dashBufferCounter > 0f && !hasDashed;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        horizontalDirection = GetInput().x;
        verticalDirection = GetInput().y;
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashBufferCounter = dashBufferLength;
        }
        else
        {
            dashBufferCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (canDash)
            StartCoroutine(Dash(horizontalDirection, verticalDirection));

    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    IEnumerator Dash(float x, float y)
    {
        float dashStartTime = Time.time;
        hasDashed = true;
        isDashing = true;

        rBody.velocity = Vector2.zero;
        rBody.gravityScale = 0f;
        rBody.drag = 0f;

        Vector2 dir;
        if (x != 0f || y != 0f)
            dir = new Vector2(x, y);
        else
        {
            if (moveX >= 0.1)
            {
                dir = new Vector2(1f, 0f);
            }
            else
            {
                dir = new Vector2(-1f, 0f);
            }
        }

        while (Time.time < dashStartTime + dashLength)
        {
            rBody.velocity = dir.normalized * dashSpeed;
            yield return null;
        }

        isDashing = false;
    }

    */
}
