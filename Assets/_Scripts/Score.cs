using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Fisher
public class Score : MonoBehaviour {

    //Declaring the variables
    public float time = 0;
    //declares score
    public float score = 0;
    //declares the score increment
    public static float scoreAdd = 1;
    //declares the delay at which score was added
    public float delay = 1;

    //Declaring things for the for the (f)UI
    public Text scoreText;
    public Text timeText;

    PlayerController playerController;
    public GameObject player;



	// Use this for initialization
	void Start ()
    {

        //Starts WaitAndAdd
        StartCoroutine(WaitAndAdd());
        //playerController = player.GetComponent<PlayerController>();



    }

    // Update is called once per frame
    void Update ()
    {
        //Creates the time to start up
        time += Time.deltaTime * 10;
        setTimeText();
        
        //Debug.Log(time);
    }

    //increments score
    public void IncrementScore()
    {
            score = score + scoreAdd;
            StartCoroutine(WaitAndAdd());
            setScoreText();
    }


    //Waits waitTime seconds and increments score by scoreAdd 
     private IEnumerator WaitAndAdd()
    {
        //tells it to wait for (delay) seconds
        yield return new WaitForSeconds(delay);
        //increment the score
        IncrementScore();
        
    }

    public void setScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void setTimeText()
    {
        timeText.text = Mathf.RoundToInt(time).ToString();
    }
}
