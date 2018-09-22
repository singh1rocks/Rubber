using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        var damage = collision.gameObject;
        var health = damage.GetComponent<PlayerHealth>();
        if(health != null)
        {
            health.takeDamage(1);
        }
    }
}
