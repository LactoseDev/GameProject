using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Health
{
    // Sprite to desplay when starting to break
    [SerializeField] private Sprite crackedBox;
    // VFX feedback when it breaks
    [SerializeField] private GameObject brokenFX;

    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);

        // Swaps the sprite when player jumps on it
        this.gameObject.GetComponent<SpriteRenderer>().sprite = crackedBox;

        if (currentHealth <= 0)
        {
            // Play the smoke effects when box breaks
            Instantiate(brokenFX, gameObject.transform.localPosition, Quaternion.identity);

            // Spawn Collectibles


            // Destory the Box
            Destroy(gameObject);
        }

    }

}
