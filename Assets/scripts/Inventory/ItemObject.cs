using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickUpItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
        Debug.Log("Inventory System: " + (InventorySystem.current != null));
    }


}
