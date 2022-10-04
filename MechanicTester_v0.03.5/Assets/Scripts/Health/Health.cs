using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Health Values
    public int currentHealth;
    public int maxHealth;

    // Heart Images
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Sprite Holder
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure the number of hearts displaying doesn't exceed maximum health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealth();
    }

    //---------------- Custom Functions -------------------

    void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }

    public virtual void HandleDamage(int damageValue)
    {
        currentHealth -= damageValue;

        // Starts the Flash
        if (currentHealth >= 1 && gameObject.CompareTag("Player"))
        {
            StartCoroutine(FlashRed());
        }

    }

    // Handle Flash Red
    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

}
