using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNailSwing : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rBody;
    private Animator anim;
    //public Transform nailPlatform;
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
            rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            rBody.velocity = new Vector2(rBody.velocity.x, swingJumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SwingDistance"))
        {
            inSwingingRange = true;
            interactable = true;
            // Jump Reset (not working)
            //nailPlatform = other.transform.GetChild(0);
            //CircleCollider2D collider = nailPlatform.GetChild(0).GetComponent<CircleCollider2D>();

            /*if (isSwinging == true)
            {
                // Jump Reset
                //transform.GetChild(0).gameObject.transform.rotation = Quaternion.identity;
                //transform.GetChild(0).gameObject.SetActive(true);

                //other.transform.GetChild(0).gameObject.transform.rotation = Quaternion.identity;
                //other.transform.GetChild(0).gameObject.SetActive(true);

                //Transform nailPlatform = nailPlatform.GetChild(0).gameObject.transform.rotation = Quaternion.identity;
                //nailPlatform.GetChild(0).gameObject.SetActive(true)

                //Transform transform = nailPlatform.GetChild(0).GetComponent<BoxCollider2D>();
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }*/

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SwingDistance"))
        {
            inSwingingRange = false;
            interactable = false;
        }
    }

    private IEnumerator Swing()
    {
        canSwing = false;
        isSwinging = true;
        // Stores the original Constraints on the player
        var originalConstraints = rBody.constraints;
        // Stores the original gravity and changes it to 0
            //float originalGravity = rBody.gravityScale;
            //rBody.gravityScale = 0f; 
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
            //rBody.gravityScale = originalGravity;
        rBody.constraints = originalConstraints;
        isSwinging = false;
        Debug.Log("is no longer swinging!");
            //anim.SetBool("isSwinging", false);
        canSwing = true;
    }

}
