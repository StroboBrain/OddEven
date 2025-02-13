using System.Threading;
using TMPro;
using UnityEngine;

// Updates the timer with the time from the timer class
public class TimerUpdate : MonoBehaviour
{
    private TextMeshPro tmpText;

    //Stores the time in milliseconds
    private float timer;

    void Start()
    {
        //Get text component
        tmpText = gameObject.GetComponent<TextMeshPro>();
    }

    void FixedUpdate()
    {
        UpdateTextbox();
    }
    void UpdateTextbox()
    {
        // Dont update if there is no new time or timer is not running
        float newTime = Timer.GetTime();
        if (timer != newTime && Timer.TimerIsRunning()){
        //Update the text
        tmpText.text = TimeConverter.MillisecondsToTimerString(newTime);
        }
    }
}
