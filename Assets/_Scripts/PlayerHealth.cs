using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 3;
    public int currentHealth = maxHealth;
    public GameObject player;
    Rigidbody p;
    public bool freeze;

	// Use this for initialization


    void Start()
    {
        p = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("Health: " + currentHealth);
        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(1);
        }
    }
    public void takeDamage(int amount)
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            p.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (freeze == true)
        {
            currentHealth = 0;
            p.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            Debug.Log("Frozen");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            takeDamage(1);
        }
    }
}
