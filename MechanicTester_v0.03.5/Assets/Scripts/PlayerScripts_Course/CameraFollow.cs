using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;
    [SerializeField] private float boundX = 0.15f;
    [SerializeField] private float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // Check if player is within X bounds
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                deltaX = deltaX - boundX;
            }
            else
            {
                deltaX = deltaX + boundX;
            }

        }

        // Check if player is within Y bounds
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                deltaY = deltaY - boundY;
            }
            else
            {
                deltaY = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0); 
    }
}
