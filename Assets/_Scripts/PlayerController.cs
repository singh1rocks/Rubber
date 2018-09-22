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
    private bool canDoubleJump;
    private bool jumpAgain;

    private int maxJumps;
    public float powerUpTimer = 5f;
    public float powerUpCounter = 0f;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody>();
        Health = playerRB.GetComponent<PlayerHealth>();
        isGrounded = true;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        maxJumps = 1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        movementVector = Vector3.zero;

        movementVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

        movementVector.z = forwardSpeed;

        playerRB.AddForce(movementVector);

	}

    void Update(){

        if (Input.GetKeyDown(KeyCode.Space) && maxJumps > 0)
        {
            playerRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            maxJumps -= 1;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Health.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Health.enabled = true;
        }

        if(maxJumps <= 0 && isGrounded)
        {
            maxJumps = 1;
        }

        if(powerUpCounter >= 0)
        {
            powerUpCounter -= Time.deltaTime;
            
        }
        else
        {
            Score.scoreAdd = 1;
        }

        //Debug.Log(maxJumps);

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Double Jump"))
        {
            //canDoubleJump = true;
            maxJumps += 1;
            Debug.Log("Can double jump!");
        }

        if(other.gameObject.CompareTag("2x Score"))
        {
            Score.scoreAdd = 2;
            powerUpCounter = powerUpTimer;
        }
    }
}
