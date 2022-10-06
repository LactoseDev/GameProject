using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    // Active button sprite
    [SerializeField] private Sprite pressedButtonSprite;
    // Door you want ot link to the button
    [SerializeField] private GameObject door;

    // Saftey Checks
    private bool interactable = false;
    private bool doorOpened = false;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // Set the button bool to true to allow it to be pressed
        if (doorOpened == false)
        {
            // This will run the base function so that the interact prompt pops up and dissapears
            base.OnTriggerEnter2D(collision);
            // If the door hasn't already been opened lets the player interact with the button
            interactable = true;
        }
    }

    private void Update()
    {
        // Checks to see if the player pressed E while in front of the button
        if (Input.GetKeyDown(KeyCode.E) && interactable == true)
        {
            // Makes it so you can't press the button again
            interactable = false;
            // Makes it so you can't leave the collider and come back in and press it again
            doorOpened = true;

            // Changes the button to green
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressedButtonSprite;
            // Gets the door script and runs the open door function from it
            door.GetComponent<Door>().OpenDoor();
        }
    }


}
