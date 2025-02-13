using System;
using UnityEngine;

// Helper function for timer conversion
public static class TimeConverter
{
    public static String MillisecondsToTimerString(float timer){
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer * 100) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public static float ConvertToMilliseconds(string time)
    {

        // Split the input string into its components
        string[] timeParts = time.Split(':');

        // Parse the minutes, seconds, and milliseconds
        int minutes = int.Parse(timeParts[0]);
        int seconds = int.Parse(timeParts[1]);
        int milliseconds = int.Parse(timeParts[2]);

        // Calculate the total time in milliseconds
        float totalMilliseconds = (minutes * 60 * 1000) + (seconds * 1000) + milliseconds;

        return totalMilliseconds;
    }

}
