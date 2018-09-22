using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour {
    public Score timer;
    public Coin doubled;
    

	// Use this for initialization
	void Start () {
        GameObject time = GameObject.Find("ScoreObject");
        GameObject isDoubled = GameObject.Find("Coin");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Timer()
    {
        double endTime = timer.time + 5;
        while(timer.time < endTime)
        {
            doubled.isDoubled = true;
        }
    }
}
