using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerFollow : MonoBehaviour {

    GameObject player;
    float HorizontalSpeed;

    Animator animator;


	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); // The player object
        animator = GetComponentInChildren<Animator>();
        animator.Play(0);
    }

	void Update () {
        float desiredX = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref HorizontalSpeed, .1f);
        transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y, desiredX);
	}
}
