using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.gameObject.CompareTag("Player"))
            return;

        TriggerPickUp(coll.gameObject);
    }

    protected abstract void TriggerPickUp(GameObject targetGameObject);

}
