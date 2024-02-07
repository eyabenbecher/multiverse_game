using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryUI : MonoBehaviour
{
    private InventorySystem inventorySystem;
    public GameObject m_slotPrefab;
    //inventory = new List<InventoryItem>();
    // Start is called before the first frame update
    public void Start()
    {
        inventorySystem = InventorySystem.current;

        if (inventorySystem != null)
        {
            inventorySystem.onInventoryChangedEvent += OnUpdateInventory;
        }
        else
        {
            Debug.LogError("InventorySystem.current is null. Make sure the InventorySystem is properly initialized.");
        }
    }

        private void OnUpdateInventory()
    {
        DrawInventory();
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        
    }
    public void DrawInventory()
    {
        foreach (InventorySystem.InventoryItem item in InventorySystem.current.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventorySystem.InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);
        SlotScript slot = obj.GetComponent<SlotScript>();
        slot.Set(item);
    }
}
