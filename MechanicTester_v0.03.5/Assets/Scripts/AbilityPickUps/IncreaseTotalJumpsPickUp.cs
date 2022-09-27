using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTotalJumpsPickUp : PickUp
{
    protected override void TriggerPickUp(GameObject targetGameObject)
    {
        if (!targetGameObject.TryGetComponent(out PlayerJump playerJump))
            return;

        playerJump.IncrementTotalJumps();
        Destroy(gameObject);
    }
}
