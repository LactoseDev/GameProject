using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailSwing : MonoBehaviour
{
    //public GameObject player;
    //private Rigidbody2D rBody;

    //private bool canSwing = true;
    //private bool isSwinging;

    public bool playerInRange;
    [SerializeField] private GameObject interactPrompt;

    //private bool interactable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && interactable == true)
            {
                interactPrompt.SetActive(false);
                //StartCoroutine(Swing());
            }
        }*/
    }

    // Checks to see if the player is in the range of the swing
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Says the player is in range
            playerInRange = true;
            // That the swing is interactiable
            //interactable = true;
            // prompts the button to press
            interactPrompt.SetActive(true);
            // gets the players rigidbody2d component
            //other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // turns the options off when player out of range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            //interactable = false;
            interactPrompt.SetActive(false);
        }
    }


}
