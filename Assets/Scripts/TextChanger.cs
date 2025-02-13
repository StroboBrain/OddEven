using UnityEngine;
using TMPro; // Namespace to use TextMesh Pro

public class TextChanger : MonoBehaviour
{
    private TMP_Text tmpText; // Reference to the TMP_Text component

    void Start()
    {
        // Get the TMP_Text component attached to the same GameObject
        tmpText = GetComponent<TMP_Text>();
    }

    void Update()
    {
       
    }

    public void ChangeText(string newText)
    {
        tmpText.text = newText;
    }
}
