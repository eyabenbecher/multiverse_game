using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItem referenceItem;

    public void OnHandlePickUpItem()
    {
        inventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
        Debug.Log("Inventory System: " + (inventorySystem.current != null));
    }


}
