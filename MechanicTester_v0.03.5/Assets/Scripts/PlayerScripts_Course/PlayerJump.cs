using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : CharacterJump
{
    [SerializeField] private int totalJumps = 1;
    [SerializeField] private int currentJumpCount;

    protected override void Start()
    {
        onGrounded += ResetJumpCount;
        onJump += DecreaseJumpCount;
        base.Start();
    }

    protected override void Update()
    {
        if (Input.GetButtonDown("Jump") && currentJumpCount > 0)
        {
            DoJump();
        }

        if (Input.GetButtonUp("Jump") && rBody.velocity.y > 0)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }

        base.Update();
    }



    void ResetJumpCount()
    {
        currentJumpCount = totalJumps;
    }

    void DecreaseJumpCount()
    {
        currentJumpCount--;
    }
}
