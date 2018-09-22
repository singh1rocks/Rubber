using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerFollow : MonoBehaviour {

    public GameObject player;
    float HorizontalSpeed;

    Animator animator;


	void Start () {
       // player = GameObject.FindGameObjectWithTag("Player"); // The player object
        animator = GetComponentInChildren<Animator>();
        animator.Play(0);
    }

	void Update () {
        float desiredX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref HorizontalSpeed, .1f);
        transform.position = new Vector3(desiredX, player.transform.position.y, player.transform.position.z - 3);
	}
}
