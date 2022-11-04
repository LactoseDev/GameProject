using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBreakablePlatform : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;

    public Sprite brokenPlatformSprite;
    public float platformEndurance;
    public float platformRepairTime;
    private bool isBreaking = false;
    private bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBroken == true)
        {
            StartCoroutine(RepairPlatform());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BreakPlatform());
        }
    }

    public IEnumerator BreakPlatform()
    {
        // Start Breaking
        isBreaking = true;
        //Switch Sprite to breaking one
        //spriteRenderer.sprite = brokenPlatformSprite;
        yield return new WaitForSeconds(platformEndurance);
        // 'Break' the Platform
        transform.GetChild(0).gameObject.SetActive(false);
        isBroken = true;

    }

    private IEnumerator RepairPlatform()
    {
        yield return new WaitForSeconds(platformRepairTime);
        transform.GetChild(0).gameObject.SetActive(true);
        isBreaking = false;
        isBroken = false;
    }


}
