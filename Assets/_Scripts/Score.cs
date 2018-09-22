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
        //Creates the time to start up
        time += Time.deltaTime * 10;
        //waits waitTime seconds and increments score by scoreAdd
        WaitAndAdd(5, 1);
        
        //Debugging
        Debug.Log(score);
        Debug.Log(time);
	}


    //Waits waitTime seconds and increments score by scoreAdd 
    IEnumerator WaitAndAdd(float waitTime, int scoreAdd)
    {
        yield return new WaitForSeconds(waitTime);
        score = score + scoreAdd;
        
    }
}
