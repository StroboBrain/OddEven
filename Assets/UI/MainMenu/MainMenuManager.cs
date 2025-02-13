using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] UIDocument _document;

    [Tooltip("Enables debugging for this script")]
    [SerializeField] bool debuggerUIManager = false;
 
    Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _document = GetComponent<UIDocument>();
        
        // Adds the functions and attributes to all elements
        SetUpElements();
        
    }


    

    void SetUpElements(){
        // Using  uxml string references for the moment
        RegisterButtonEvent("start-button",OnPlayGameClick);
    }

    // Sets up a Callback event with a methode from this class
    private void RegisterButtonEvent(string buttonName, EventCallback<ClickEvent> callback)
    {
        Button button = _document.rootVisualElement.Q<Button>(buttonName);
        if (button != null)
        {
            button.RegisterCallback(callback);
        }
        else if (debuggerUIManager)
        {
            Debug.LogWarning($"Button '{buttonName}' not found.");
        }
    }

    // Methodes for the fuctionality for the buttons
    private void OnPlayGameClick(ClickEvent evt){
    {
        if (debuggerUIManager){
            Debug.Log("Button Clicked: " + startButton.name);
        }
        SceneManager.LoadScene("GameScene");
    }
    }

}