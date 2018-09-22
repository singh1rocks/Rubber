using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 3;
    public int currentHealth = maxHealth;

    bool isDead;
    bool isDamaged;

	// Use this for initialization
	public void takeDamage(int amount)
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
