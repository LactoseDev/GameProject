using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelTrigger : MonoBehaviour
{
    public GameObject finishScreen;
    public SpriteRenderer SpriteRenderer;
    public Sprite activeSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishScreen.SetActive(true);
            SpriteRenderer.sprite = activeSprite;
        }
    }
}
