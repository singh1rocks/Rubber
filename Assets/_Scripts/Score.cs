using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


    public double time;
    public double score;


	// Use this for initialization
	void Start ()
    {

        time = 0;
        score = 0;
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime * 10;
        createScore();

        Debug.Log(score);
        Debug.Log(time);
	}

    public void createScore()
    {
        score = time * 2;
    }

    public void doubleScore()
    {
        

    }
}
