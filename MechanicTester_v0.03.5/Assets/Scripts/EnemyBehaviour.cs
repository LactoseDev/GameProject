using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // References
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    private EnemyPerception enemyPerception;
    private Animator anim;

    public bool flipped;

    public float moveSpeed;
    public float stopDistance;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyPerception = GetComponentInChildren<EnemyPerception>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Want enemy to face the player
        FacePlayer();

        // Want enemy to follow the player
        if (!EnemyHealth.frozen)
            FollowPlayer();
    }

    private void FacePlayer()
    {
        if (enemyPerception.playerInRange == true)
        {
            flipped = player.transform.position.x < transform.position.x;
            spriteRenderer.flipX = flipped;
        }

    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > stopDistance && enemyPerception.playerInRange == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
        else if (enemyPerception.playerInRange == true)
        {
            // Attack
        }
    }

}
