using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used on the camera to destroy unused objects that fall behind the player
/// </summary>
public class DestroyOnContact : MonoBehaviour {

    private string GroundTag = "ground";

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag(GroundTag)) {
            Destroy(col.gameObject);

        }
    }
}
