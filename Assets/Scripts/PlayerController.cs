using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Fields
    public float horizontalInput;
    public float speed = 10.0f;

    bool inboud = true;

    //private TouchControls touchControls;


    public Vector3 newPosition;

    private AudioSource endAudio;

    //public HighScoreManager highScoreManager;

    public float inRange = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is

    public bool debugPlayercontroller = false;

    public static event Action OnPlayerFallsOf;
    
    public float flatThreshold = 10f;
    void Start()
    {
        endAudio = GetComponent<AudioSource>();

        //touchControls = new TouchControls();
        //touchControls.Touch.TouchPress.started += ctx => newPosition = StartTouch(ctx);
        //touchControls.Touch.TouchPress.ended += ctx => newPosition = StartTouch(ctx); 

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = -Input.GetAxis("Horizontal");
        if(PlayerAllowedToMove()){
            transform.Translate(Vector3.right * horizontalInput* Time.deltaTime * speed);
        }
        else if (debugPlayercontroller){
            Debug.Log("Player is not allowed to move");
        }

        // Chicken falls off the platform
        if(PlayerOutOfBound()){
            if (inboud){
                InvokeRepeating("PlayEndSound",0.0f,3.0f);

            }
            OnPlayerFallsOf?.Invoke();


            inboud = false;
        }

        
    }

    bool PlayerAllowedToMove(){
        return IsFlat();
    }

    bool PlayerOutOfBound(){
        return transform.position.y<-15.0f;
    }




    //Checks if the player is flat
    bool IsFlat(){
        Quaternion roation = transform.rotation;
        if (debugPlayercontroller){
            Debug.Log("Player Rotation: " + roation);
        }
        return roation.x<flatThreshold;
    }

   void PlayEndSound(){
        endAudio.Play();
    }

    // Touch Control Funktions TODO
    // private void StartTouch(InputAction.CallbackContext context)
    // {
    //     Debug.Log("Touch started");
    // }
    // private void EndTouch(InputAction.CallbackContext context)
    // {
    //     Debug.Log("Touch ended");

    // }


}
