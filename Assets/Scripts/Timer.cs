using System;
using TMPro;
using UnityEngine;

// Times the running level
public class Timer : MonoBehaviour
{
    // Time the player is alive
    private static float levelTimer = 0f;

    // Time since the last task was asked


    private static bool timerIsRunning = false;

    void Awake()
    {
        levelTimer = 0f;
    }

    void FixedUpdate()
    {
        // Update the levelTimer if it's running
        if (timerIsRunning)
        {
            levelTimer += Time.deltaTime;
        }
    }
    public static void StartTimer()
    {
        timerIsRunning = true;
    }

    public static void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        timerIsRunning = false;
        levelTimer = 0f;
    }

    public static bool TimerIsRunning(){
        return timerIsRunning;
    }

    public static float GetTime(){
        return levelTimer;
    }

}
