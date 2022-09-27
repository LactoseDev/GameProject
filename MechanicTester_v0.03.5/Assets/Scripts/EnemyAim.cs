using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject player;
    public GameObject self;

    Vector2 playerPos;
    private Rigidbody2D rBody;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        rBody.transform.position = new Vector2(self.transform.position.x, self.transform.position.y);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = playerPos - rBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rBody.rotation = angle;
    }
}
