using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private Flipper flipperR; // Reference to the Flipper script
    private Flipper flipperL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float angle = 120f; // Angle to rotate the platform

    [SerializeField] int lowestNumber = 0;

    [SerializeField] int highestNumber = 100;

    [SerializeField] float taskCreationDelay = 1f;



    private float timer = 0f;

    private TextChanger textChanger;

    private int task = -1;

    public float taskSpeed = 5;

    bool flipped = false;

    float timeOfLastTask = 0f;

    private bool gameIsRunning;



    

    private PlayerController playerController;



    void Start()
    {
        // Find the GameObjects with the Flipper script attached
        GameObject evenObjectR = GameObject.Find("Rechts");
        GameObject evenObjectL = GameObject.Find("Links");
        flipperR = evenObjectR.GetComponent<Flipper>();
        flipperL = evenObjectL.GetComponent<Flipper>();

        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        
        GameObject TextField = GameObject.Find("TextField");
        textChanger = TextField.GetComponent<TextChanger>();

        Invoke("CreateTask",2f);
        Timer.StartTimer();
        gameIsRunning = true;

        //Subscribe to the event, if the player falls of
        PlayerController.OnPlayerFallsOf += HandlePlayerOfPlatform;

    }

    // Update is called once per frame
    void LateUpdate()
    {   
        timer = Timer.GetTime();
        //timer += Time.deltaTime; // Update the timer
        if (timer > taskSpeed + timeOfLastTask)
        {
           Invoke("CreateTask",taskCreationDelay);
           if (!flipped){
            FlipPlatform();
           }

        }

        


        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame(); // Call the method to restart the game
        }
        
    }


    // Good practise to unsubscribe
    private void OnDisable(){
        PlayerController.OnPlayerFallsOf -= HandlePlayerOfPlatform;

    }


    // Creates a task and updates the text
    void CreateTask(){
            if (gameIsRunning){
                task = Random.Range(lowestNumber, highestNumber);
            textChanger.ChangeText(task.ToString());
            timeOfLastTask = timer;
            }
        }
    
    void RestartGame(){
        Debug.Log("Restarting the game");
        
         // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }
    
    private void HandlePlayerOfPlatform(){
        Timer.StopTimer();
        gameIsRunning = false;
        textChanger.ChangeText("GAME OVER");
    }

    private void FlipPlatform(){
        if (task%2==0){
                flipperL.FlipAndBack(-120f);
            }
            else {
                flipperR.FlipAndBack(120f);
        }

        flipped = true;
        // 1 Seconde cooldown
        Invoke("ChangeFlippedStatus",1f);
    }

    private void ChangeFlippedStatus(){
        flipped = !flipped;
    }




}
