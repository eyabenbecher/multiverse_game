using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour 
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        uiInventory.SetInventory(inventory);
    }
}
