using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    public GameObject checkpoint;
    private Checkpoint checkpointScript;

    // Start is called before the first frame update
    void Start()
    {
        checkpointScript = checkpoint.GetComponent<Checkpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && checkpointScript)
        {
            collision.transform.position = checkpoint.transform.position;
        }
    }
}
