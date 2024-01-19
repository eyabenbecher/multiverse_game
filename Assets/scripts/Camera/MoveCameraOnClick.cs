using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveCameraOnClick : MonoBehaviour, IPointerClickHandler
{
    
    public CinemachineVirtualCamera virtualCamera;

   
    public Transform targetPositionmars;
    public Transform targetPositionvenus;


    public float followSpeed = 4000f;
    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;
    



    private bool isUIVisible = false;
 
    public void OnPointerClick(PointerEventData eventData)
    {
        
        MoveCameramars();

        uiElement1.SetActive(isUIVisible);
        uiElement2.SetActive(isUIVisible);
        uiElement3.SetActive(true);
    }
    public void OnButtonClickvenus()
    {
        MoveCameravenus();
        uiElement3.SetActive(false);
        uiElement4.SetActive(true);



    }
    public void OnButtonClickmars()
    {
        MoveCameramars();
        uiElement3.SetActive(true);
        uiElement4.SetActive(false);



    }
    public void OnButtonClickvisitmars()
    {


        SceneManager.LoadScene("mars");

    }
    public void OnButtonClickvisitvenus()
    {


        SceneManager.LoadScene("venus");

    }



    private void MoveCameramars()
    {
        
        if (virtualCamera != null)
        {

            
            CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer != null)
            {

                
                transposer.m_FollowOffset = new Vector3(0, 0, 0);
            }

            
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targetPositionmars.position, Time.deltaTime * followSpeed);
        }
        else
        {
            Debug.LogError("Virtual Camera not assigned!");

        }
    }
    private void MoveCameravenus()
    {

        if (virtualCamera != null)
        {


            CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer != null)
            {


                transposer.m_FollowOffset = new Vector3(0, 0, 0);
            }


            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targetPositionvenus.position, Time.deltaTime * followSpeed);
        }
        else
        {
            Debug.LogError("Virtual Camera not assigned!");

        }
    }

}
