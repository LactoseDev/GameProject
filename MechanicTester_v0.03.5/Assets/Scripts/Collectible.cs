using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int collectibleValue;
    public GameObject collectedVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collecting Things Logic
        if (collision.gameObject.CompareTag("Player"))
        {
            // Passes information the player inventory
            collision.gameObject.GetComponent<ItemManager>().HandleCollectible(collectibleValue);
            // Hanles visual feedback
            StartCoroutine(Collected());
        }
    }

    public IEnumerator Collected()
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = null;
        Instantiate(collectedVFX, gameObject.transform.localPosition, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
