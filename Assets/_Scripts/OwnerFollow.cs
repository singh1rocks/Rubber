using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerFollow : MonoBehaviour {

    public GameObject player; // The player object.
    float HorizontalSpeed; // Should not be touched. Can be read to get the change in the desired X position.
    float ForwardSpeed; // Should not be touched. Can be read to get the change in the desired Z position.
    private float rayDistance = 100f; // Should be some remarkably high but stable distance.

    Animator animator;


	void Start () {
        // player = GameObject.FindGameObjectWithTag("Player"); // The player object.
        animator = GetComponentInChildren<Animator>();
        animator.Play(0);
    }

	void Update () {
        float yPos = determineYOffset();
        Rigidbody rBody = player.GetComponent<Rigidbody>();
        float desiredX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref HorizontalSpeed, .1f);
        float desiredZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z - (1 + rBody.velocity.z * .2f), ref ForwardSpeed, .15f);
        transform.position = new Vector3(desiredX, yPos, desiredZ);
	}

    public float determineYOffset()
    {
        // Determine the standing position of the actor based on the ground below him.
        Ray rayDown = new Ray(transform.position - new Vector3(0,-.5f), Vector3.down * rayDistance);
        //Debug.DrawRay(transform.position - new Vector3(0, -.5f), Vector3.down * rayDistance, Color.red);
        RaycastHit hit = new RaycastHit();
        float yOffset = 0f;
        Physics.Raycast(rayDown, out hit, rayDistance);
        if (hit.collider == null) return player.transform.position.y;
        return (hit.point.y + yOffset);
    }
}
