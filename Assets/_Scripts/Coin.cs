using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public Score myScore;
    public bool isDoubled;

    private void Start()
    {
        GameObject score = GameObject.Find("ScoreObject");
    }
    private void OnTriggerEnter(Collider Score)
    {
        if (isDoubled)
        {
            myScore.score += 20;
        }
        else
        {
            myScore.score += 10;
        }
        Destroy(this);
    }
}
