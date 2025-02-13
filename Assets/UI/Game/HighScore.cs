using System;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private TextMeshPro tmpText;
    private float timer;


    void Start()
    {
        // Get text component
        tmpText = gameObject.GetComponent<TextMeshPro>();
    }

    public void UpdateHighScore(int minutes, int seconds, int milliseconds)
    {
        // Uses the format from TimerUpdate
        tmpText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void UpdateHighScore(String text){
        tmpText.text = text;
    }
}