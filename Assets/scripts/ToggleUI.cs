using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    
    public GameObject uiElement;

    
    private bool isUIVisible = false;

   
    public void OnButtonClick()
    {
       
        isUIVisible = !isUIVisible;

       
        uiElement.SetActive(isUIVisible);
    }
}
