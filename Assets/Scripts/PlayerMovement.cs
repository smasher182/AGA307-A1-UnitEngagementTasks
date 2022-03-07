using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // reference to character controller on player.
    public CharacterController controller;
    // reference to player speed.
    public float speed = 12f;
    // reference to gravity on player.
    public float gravity = -9.81f;
    // reference to player max jump height. 
    public float jumpHeight = 3f;

    // reference to groundCheck if the player hits the ground.
    public Transform groundCheck;
    // reference to radius of groundCheck sphere.
    public float groundDistance = 0.4f;
    // reference to masked objects that groundcheck sphere checks for.
    public LayerMask groundMask;

    // reference to current velocity of player.
    Vector3 velocity;
    // bool check if the player is grounded or not.
    bool isGrounded;

    private void Update()
    {
        // checks if the player is grounded based on a physics check.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            // zero velocity means the player stops moving, but physics check could register before the players hits the ground.
            // small -ve value makes sure the player is grounded.
            velocity.y = -2f;
        }

        // creates inputs for player movement.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // moves the player in the direction they are facing.
        Vector3 move = transform.right * x + transform.forward * z;
        //refers to character controller for player movement.
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //makes the player jump off the ground based on gravity and max height that it can jump.
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // adds fall velocity to the player based on gravity. 
        velocity.y += gravity * Time.deltaTime;
        // assigns the velocity to the controller for movement.
        controller.Move(velocity * Time.deltaTime);
    }

}