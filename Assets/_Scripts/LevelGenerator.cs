using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows the given game object and generates ground objects up to a certain distance away
/// </summary>
public class LevelGenerator : MonoBehaviour {

    public GameObject player;

    public float genDistance = 10f;

    public float maxOffset = 3f;

    /// <summary>
    /// A prefab that has a child 'StartPoint' transfrom and a child 'EndPoint' transform.
    /// </summary>
    public List<GameObject> groundObjects = new List<GameObject>();

    /// <summary>
    /// The position of the player when we last generated a ground object
    /// </summary>
    private Vector3 lastSpawnPosition;

    private GameObject lastGroundObject;

    void Start() {
        lastGroundObject = Instantiate(RandomGroundObject());
        lastGroundObject.transform.position = player.transform.position + Vector3.down * 2f + Vector3.forward * 2f ;
        lastSpawnPosition = lastGroundObject.transform.Find("EndPoint").position;
    }

	void Update () {
		if ( Vector3.Distance( lastSpawnPosition,  player.transform.position ) < genDistance) {
            SpawnNewGroundObject();
            lastSpawnPosition = lastGroundObject.transform.Find("EndPoint").position;
        }
	}

    private GameObject RandomGroundObject() {
        int r = Mathf.FloorToInt(Random.value * groundObjects.Count);
        return groundObjects[r];
    }

    private void SpawnNewGroundObject() {
        var lastEndPoint = lastGroundObject.transform.Find("EndPoint");

        lastGroundObject = Instantiate(RandomGroundObject());
        
        var thisStartPoint = lastGroundObject.transform.Find("StartPoint");

        // use the 'endPoint' on the last ground object and the 'start point' on the new one
        // position the new ground object with the end of this one touching the end of the last one
        lastGroundObject.transform.position =  lastEndPoint.position - (thisStartPoint.position - lastGroundObject.transform.position);

        // translate the new game object by a random amount left or right
        lastGroundObject.transform.position += Vector3.right * maxOffset * ( Random.value * 2f - 1f );
    }
}
