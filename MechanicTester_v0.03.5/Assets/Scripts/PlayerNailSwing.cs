using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNailSwing : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rBody;
    private Animator anim;
    //private PlayerJump playerJump;
    //private NailProjectile nailPosition;

    private bool canSwing = true;
    private bool isSwinging;
    [SerializeField] private float swingJumpForce = 15f;
    [SerializeField] private float pinnedDuration = 3f;

    public bool inSwingingRange;

    private bool interactable = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //playerJump = GetComponent<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inSwingingRange == true)
        {
            //nailPosition = other.gameObject.GetComponent<NailProjectile>();
            if (Input.GetKeyDown(KeyCode.E) && interactable == true)
            {
                StartCoroutine(Swing());
            }
        }

        if (Input.GetButtonUp("Jump") && isSwinging == true)
        {
            isSwinging = false;
            //anim.SetBool("isSwinging", false);
            rBody.gravityScale = 1f;
            rBody.constraints = RigidbodyConstraints2D.None;
            rBody.velocity = new Vector2(rBody.velocity.x, swingJumpForce);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NailPlatform"))
        {
            inSwingingRange = true;
            interactable = true;
            //nailPosition = new Vector2()
            //NailSwing nailSwing = other.gameObject.GetComponent<NailSwing>();
            //nailSwing.Swing();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NailPlatform"))
        {
            inSwingingRange = false;
            interactable = false;
        }
    }

    private IEnumerator Swing()
    {
        canSwing = false;
        isSwinging = true;
        // Stores the original gravity and changes it to 0
        float originalGravity = rBody.gravityScale;
        rBody.gravityScale = 0f; 
        // Stops the current movement of the player
        rBody.velocity = Vector2.zero;
        // Freezes the players constrains so it can't move
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        // Starts the Swinging animation
        //anim.SetBool("isSwinging", true);
        Debug.Log("is swinging!");
        // stop the player at the center of the nail
        //player.transform.position = nailPosition.savedPosition;
        // Reset the players jump count
        //playerJump.ResetJumpCount();
        yield return new WaitForSeconds(pinnedDuration);
        rBody.gravityScale = originalGravity;
        rBody.constraints = RigidbodyConstraints2D.None;
        rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        isSwinging = false;
        Debug.Log("is no longer swinging!");
        //anim.SetBool("isSwinging", false);
        canSwing = true;
    }

}
