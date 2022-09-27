using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    protected override void Update()
    {
        SetMoveX(Input.GetAxisRaw("Horizontal"));
        base.Update();

    }
}
