using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    
    Rigidbody playerRB;
    PlayerHealth Health;

    private Vector3 movementVector;
    private Vector3 jump;

    public float forwardSpeed;
    public float horizontalSpeed;
    public float jumpForce;

    private bool isGrounded;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody>();
        Health = playerRB.GetComponent<PlayerHealth>();
        isGrounded = true;
        jump = new Vector3(0.0f, 2.0f, 0.0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        movementVector = Vector3.zero;

        movementVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

        movementVector.z = forwardSpeed;

        playerRB.AddForce(movementVector);

	}

    void Update(){

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Health.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Health.enabled = true;
        }

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
}
