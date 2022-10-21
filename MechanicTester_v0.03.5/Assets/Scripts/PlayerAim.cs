using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    //public GameObject mouse;
    public GameObject player;

    Vector2 mousePos;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rBody.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - rBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rBody.rotation = angle;
    }

}
