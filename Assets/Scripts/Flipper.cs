using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Flipper : MonoBehaviour
{
    public float rotationDuration = 0.1f; // Ultra-fast duration for a rapid rotation
    public float angle = 120f; // Angle to rotate the platform
    public float waitTime = 2f; // Time to wait in seconds
    

    // This method starts the coroutine to rotate the GameObject smoothly
    public void Flip()
    {
        StartCoroutine(SmoothRotate(angle));
    }

    // Coroutine to smoothly rotate the GameObject
    private IEnumerator SmoothRotate(float angle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation ends exactly at the target rotation
        transform.rotation = endRotation;
    }

    public void FlipAndBack(float angle)
    {
        this.angle = angle;
        Flip();
        this.angle = -angle;
        Invoke("Flip", 2f);
    }




}
