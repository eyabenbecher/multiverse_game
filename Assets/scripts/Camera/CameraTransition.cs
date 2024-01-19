using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTransition : MonoBehaviour
{
    public Transform target;  // Assign the player or target object to follow
    public float transitionDuration = 4.0f;  // Duration of the transition in seconds
    public Vector3 targetPosition;  // Target position to focus on in the new scene

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned for CameraTransition script!");
        }
        else
        {
            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Ensure this object persists across scenes
            DontDestroyOnLoad(gameObject);

            // Start camera transition animation
            StartCoroutine(PerformCameraTransition());
        }
    }

    private System.Collections.IEnumerator PerformCameraTransition()
    {
        // Cache initial camera position and rotation
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        // Calculate the target position and rotation
        Vector3 targetPosition = target.position + new Vector3(0, -8f, 0);  // Adjust the height
        Quaternion targetRotation = Quaternion.Euler(0, 180, 0);

        float elapsedTime = 0;

        // First half of the transition: rotate the camera
        while (elapsedTime < transitionDuration / 2)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / (transitionDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure a smooth transition by setting the final rotation
        transform.rotation = targetRotation;

        // Ensure a smooth transition by setting the final position for the first half
        transform.position = targetPosition;

        // Reset the timer for the second half
        elapsedTime = 0;

        // Second half of the transition: move the camera back to the initial position
        while (elapsedTime < transitionDuration / 2)
        {
            transform.position = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / (transitionDuration / 2));
            transform.rotation = Quaternion.Slerp(targetRotation, initialRotation, elapsedTime / (transitionDuration / 2));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure a smooth transition by setting the final position and rotation for the second half
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Start camera transition animation
        StartCoroutine(PerformCameraTransition());
    }
}
