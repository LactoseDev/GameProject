using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    public float destroyTimer;

    public void Awake()
    {
        Destroy(gameObject, destroyTimer);
    }
}
