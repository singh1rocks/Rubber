using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public Score score;

    private void Start()
    {
        GameObject score = GameObject.Find("ScoreObject");
    }
    private void OnTriggerEnter(Collider Score)
    {
        score += 10;
        Destroy(this);
    }
}
