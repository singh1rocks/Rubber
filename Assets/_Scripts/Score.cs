using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


    public float time;
    public float score;
    public float scoreAdd = 1;
    public float delay = 1;



	// Use this for initialization
	void Start ()
    {
 
        //sets value of time to 0
        time = 0;
        //sets value of score to 0
        score = 0;
        StartCoroutine(WaitAndAdd());



    }

    // Update is called once per frame
    void Update ()
    {
        //Creates the time to start up
        //time += Time.deltaTime * 10;

        //waits waitTime seconds and increments score by scoreAdd
        Debug.Log(score);
        
        //Debug.Log(time);
    }

    public void incrementScore()
    {
            score = score + 1;
            StartCoroutine(WaitAndAdd());
    }


    //Waits waitTime seconds and increments score by scoreAdd 
     private IEnumerator WaitAndAdd()
    {
        yield return new WaitForSeconds(delay);
        incrementScore();
        
    }
}
