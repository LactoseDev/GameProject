using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGround : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    private Coroutine breakPlatformCoroutine;

    public Sprite brokenPlatformSprite;
    public float platformEndurance;
    public bool isBreaking;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBreaking == true)
        {
            Destroy(gameObject, platformEndurance / 2);
        }
        else
        {
            breakPlatformCoroutine = StartCoroutine(BreakPlatform());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBreaking == true)
        {
            // Stop Platform from breaking
            isBreaking = false;
            StopCoroutine(breakPlatformCoroutine);
        }
    }

    public IEnumerator BreakPlatform()
    {
        // Start Breaking
        isBreaking = true;
        //spriteRenderer.sprite = brokenPlatformSprite;
        yield return new WaitForSeconds(platformEndurance);
        // Break the Platform
        Destroy(gameObject);
    }

}
