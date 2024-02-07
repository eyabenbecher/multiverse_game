using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemController : MonoBehaviour
{
    // Layer mask to filter which objects can be collected
    public LayerMask collectableLayer;

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to determine what the mouse is clicking on
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, collectableLayer))
            {
                // Check if the clicked object has the ItemObject script
                ItemObject item = hit.collider.GetComponent<ItemObject>();

                if (item != null)
                {
                    item.OnHandlePickUpItem();
                }
            }
        }
    }
}
