using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows the given game object and generates ground objects up to a certain distance away
/// </summary>
public class LevelGenerator : MonoBehaviour {

    public GameObject player;

    public float genDistance = 10f;

    public List<GameObject> groundObjects = new List<GameObject>();

    /// <summary>
    /// The position of the player when we last generated a ground object
    /// </summary>
    private Vector3 lastSpawnPosition;

    void Start()

	void Update () {
		
	}
}
