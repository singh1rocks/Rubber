using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public Score myScore;

    private void Start()
    {
        GameObject score = GameObject.Find("ScoreObject");
    }
    private void OnTriggerEnter(Collider Score)
    {
        myScore.score += 10;
        Destroy(this);
    }
}
