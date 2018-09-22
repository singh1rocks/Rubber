using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows the given game object and generates ground objects up to a certain distance away
/// </summary>
public class DeathFloorGenerator : MonoBehaviour {

    public GameObject player;
    
    public float genDistance = 10f;

    public float maxOffset = 3f;

    /// <summary>
    /// A prefab that has a child 'StartPoint' transfrom and a child 'EndPoint' transform.
    /// </summary>
    public List<GameObject> deathObjects = new List<GameObject>();

    /// <summary>
    /// The position of the player when we last generated a ground object
    /// </summary>
    private Vector3 lastSpawnPosition;

    private GameObject lastDeathObjects;

    void Start() {
        lastDeathObjects = Instantiate(RandomDeathObject());
        lastDeathObjects.transform.position = player.transform.position + Vector3.down * 7f + Vector3.forward * 2f ;
        lastSpawnPosition = lastDeathObjects.transform.Find("EndPoint").position;
       
        
    }

	void Update () {
		if ( Vector3.Distance( lastSpawnPosition,  player.transform.position ) < genDistance) {
            SpawnNewDeathObject();
            lastSpawnPosition = lastDeathObjects.transform.Find("EndPoint").position;
        }
        // Debug.Log(lastDeathObjects.transform.position);
        lastDeathObjects.transform.position = player.transform.position + Vector3.down * 7f + Vector3.forward * 2f;
    }

    private GameObject RandomDeathObject() {
        int r = Mathf.FloorToInt(Random.value * deathObjects.Count);
        return deathObjects[r];
    }

    private void SpawnNewDeathObject() {
        var lastEndPoint = lastDeathObjects.transform.Find("EndPoint");

        lastDeathObjects = Instantiate(RandomDeathObject());
        
        var thisStartPoint = lastDeathObjects.transform.Find("StartPoint");

        // use the 'endPoint' on the last ground object and the 'start point' on the new one
        // position the new ground object with the end of this one touching the end of the last one
        lastDeathObjects.transform.position =  lastEndPoint.position - (thisStartPoint.position - lastDeathObjects.transform.position);

        // translate the new game object by a random amount left or right
        lastDeathObjects.transform.position += Vector3.right * maxOffset * ( Random.value * 2f - 1f );
    }
}
