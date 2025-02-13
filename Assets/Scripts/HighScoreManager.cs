using System;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private float highScore = 0;
    [SerializeField] bool debugHighScoreManager = false;

    // Script from TimerHighScore
    TextChanger timerHighScore;

    void Start()
    {
        // Load the high score from PlayerPrefs (Zero if there is no value)
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);

        if (debugHighScoreManager){
            Debug.Log("High Score: " + highScore);
        }
        //This script is used to change the text in the TimerHighScore
        timerHighScore = GameObject.Find("TimerHighScore").GetComponent<TextChanger>();
        UpdateText(highScore);

    }

    void FixedUpdate()
    {
        CheckForNewHighScore(Timer.GetTime());

    }

    public void CheckForNewHighScore(float score)
    {

        if (score>highScore)
        {
            highScore = score;
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            if (debugHighScoreManager){
            Debug.Log("New High Score: " + highScore);
            }
            UpdateText(highScore);

        }
        else{
            if (debugHighScoreManager){
                Debug.Log("No new High Score");
            }
        }
    }

    private void UpdateText(float milliseconds){
        string timeString = TimeConverter.MillisecondsToTimerString(milliseconds);
        Debug.Assert(!string.IsNullOrEmpty(timeString));
        timerHighScore.ChangeText(timeString);
    }

}
