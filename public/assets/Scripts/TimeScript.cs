using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    private float myTime;
    public Text timeText;
    // public GameObject finishingPointObject;
    public Text finalScoreText;

    private bool GameEnded;

    private FinishingPoint fp;
    private bool lastPointReached;
    // Start is called before the first frame update
    void Start()
    {
        lastPointReached = false;
        fp = FindObjectOfType<FinishingPoint>();
        Debug.Log("New method's object name is " + fp.gameObject.name);
        // at start final text will be null;
        finalScoreText.text = "";
        myTime = 0;
        timeText.text = "";
        GameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEnded)
        {
            myTime = myTime + Time.deltaTime;
            TimeSpan convertTime = TimeSpan.FromSeconds(myTime);
            timeText.text = convertTime.Minutes.ToString() + ":" + convertTime.Seconds.ToString();
        }

        if (fp.CollisionOccured())
        {
            Debug.Log("Collision occured");
            // when player hits the last point, time will be stopped
                Time.timeScale = 1;
            ShowLastScores(timeText);
            GameEnded = true;
            lastPointReached = true;
            Debug.Log("Last point reached");
        }

        if (lastPointReached)
        {
            // now start again after 4 seconds
            StartCoroutine(StartAgain());
        }
    }

    void ShowLastScores(Text fullTimeText)
    {
        finalScoreText.text = "Your beat time is : " + fullTimeText.text;
    }

    private IEnumerator StartAgain()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
