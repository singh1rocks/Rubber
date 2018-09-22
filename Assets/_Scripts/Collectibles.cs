using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.health += 1;
        Destroy(this);
   
    }
}
