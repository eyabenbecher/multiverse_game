using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.UI;

public class MoveCameraOnClick : MonoBehaviour, IPointerClickHandler
{
    
    public CinemachineVirtualCamera virtualCamera;

   
    public Transform targetPosition;

    
    public float followSpeed = 50f;
    public GameObject uiElement1;
    public GameObject uiElement2;



    private bool isUIVisible = false;
 
    public void OnPointerClick(PointerEventData eventData)
    {
        
        MoveCamera();

        uiElement1.SetActive(isUIVisible);
        uiElement2.SetActive(isUIVisible);
    }

    
    private void MoveCamera()
    {
        
        if (virtualCamera != null)
        {

            
            CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer != null)
            {

                
                transposer.m_FollowOffset = new Vector3(0, 0, 0);
            }

            
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targetPosition.position, Time.deltaTime * followSpeed);
        }
        else
        {
            Debug.LogError("Virtual Camera not assigned!");
        }
    }
}
