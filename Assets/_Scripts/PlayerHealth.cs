﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 3;
    public int currentHealth = maxHealth;
    public GameObject player;
    Rigidbody p;
    public bool freeze;
    public Text healthLabel;
	// Use this for initialization


    void Start()
    {
        p = player.GetComponent<Rigidbody>();
        currentHealth = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(1);
        }

        if (currentHealth <= 0)
        {
            p.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        healthLabel.text = currentHealth.ToString();
    }
    public void takeDamage(int amount)
    {
        currentHealth -= 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            takeDamage(1);
        }
    }
}
