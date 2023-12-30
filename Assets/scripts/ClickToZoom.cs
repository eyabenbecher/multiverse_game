using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class ZoomOnObjectClick : MonoBehaviour, IPointerClickHandler
{
    // Reference to the Cinemachine Virtual Camera
    public CinemachineVirtualCamera virtualCamera;

    // Zoom-in field of view
    public float zoomInFOV = 30f;

    // Zoom-in speed
    public float zoomSpeed = 500f;

    // Original field of view
    private float originalFOV;

    private void Start()
    {
        // Store the original field of view
        if (virtualCamera != null)
        {
            originalFOV = virtualCamera.m_Lens.FieldOfView;
        }
        else
        {
            Debug.LogError("Virtual Camera not assigned!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the clicked object has a collider
        if (eventData.pointerPressRaycast.gameObject != null)
        {
            // Zoom in on the clicked object
            ZoomIn(eventData.pointerPressRaycast.gameObject.transform);
        }
    }

    private void ZoomIn(Transform targetObject)
    {
        if (virtualCamera != null && targetObject != null)
        {
            // Set the camera's look-at target to the clicked object
            virtualCamera.LookAt = targetObject;

            // Zoom in by adjusting the field of view
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, zoomInFOV, Time.deltaTime * zoomSpeed);
        }
        else
        {
            Debug.LogError("Virtual Camera or Target Object not assigned!");
        }
    }

    // Reset the field of view to the original value
    private void ResetZoom()
    {
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.FieldOfView = originalFOV;
        }
    }

    // Call this function when you want to reset the zoom (e.g., when clicking on another object)
    public void ResetZoomOnClick()
    {
        ResetZoom();
    }
}
