using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    
    private Rigidbody playerRB;

    private Vector3 movementVector;

    public float forwardSpeed;
    public float horizontalSpeed;

    private bool isGrounded;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody>();

        isGrounded = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        movementVector = Vector3.zero;

        movementVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector.z = forwardSpeed;

        playerRB.AddForce(movementVector);

	}
}
