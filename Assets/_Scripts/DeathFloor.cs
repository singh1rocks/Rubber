using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("NO player found");
        }
        playerHP = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerHP.currentHealth = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
