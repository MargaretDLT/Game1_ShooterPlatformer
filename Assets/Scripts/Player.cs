using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public
    public float moveSpeed = 10.0f;         // units per second
    public float rotateSpeed = 90.0f;       // degrees per second
    public float jumpImpluse = 10.0f;       // units per second
    public float gravity = -9.81f;          // custom gravity

    // local
    CharacterController playerController;   // the player's character controller reference
    Vector3 moveVector;                     // current movement
    float Yvelocity;                        // gravity & jump

    // Start is called before the first frame update
    void Start()
    {
        // Store reference for character controller component
        playerController = GetComponent<CharacterController>();

        // set initital up/down movement to none
        Yvelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around y-axis based on input
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

        // set forward/backward movement based on input
        moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        // check if player is touching ground
        if (playerController.isGrounded)
        {
            // We are grounded
            // check for jump button pressed
            if (Input.GetButtonDown("Jump"))
            {
                Yvelocity = jumpImpluse;        // apply jumpImpluse
            }
        }
        else
        {
            // in the air, so apply gravity
            Yvelocity += gravity * Time.deltaTime;
        }

        // adjust the Y movement based on jumping & gravity 
        moveVector.y = Yvelocity * Time.deltaTime;

        // move forward or backward based on rotation direction, up or down with jumping & gravity
        moveVector = transform.rotation * moveVector;   // multiply by rotation
        playerController.Move(moveVector);              // use move character controller

    }
    // called when the player bumps into a rigidbody object
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Bumped " + hit.gameObject.name);
    }
}
