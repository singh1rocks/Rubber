using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    public GameObject powerUp;
    MeshRenderer powerUpMesh;
    public GameObject player;
    PlayerHealth playerHP;
	// Use this for initialization
	void Start () {
        powerUpMesh = powerUp.GetComponent<MeshRenderer>();
        playerHP = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHP.enabled = false;
            powerUpMesh.enabled = false;
        }
        else if(other.gameObject.CompareTag("Nails"))
        {
            playerHP.enabled = true;
            Destroy(gameObject);

        }
    }
}

