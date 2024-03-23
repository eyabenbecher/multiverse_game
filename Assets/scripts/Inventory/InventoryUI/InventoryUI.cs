//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class InventoryUI : MonoBehaviour
//{

//    public GameObject m_slotPrefab;
//    //inventory = new List<InventoryItem>();
//    // Start is called before the first frame update
//    public void Start()
//    {
//        //inventorySystem = InventorySystem.current;
//        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
//        //inventorySystem.onInventoryChangedEvent += OnUpdateInventory;

//    }

//    private void OnUpdateInventory()
//    {

//        foreach (Transform t in transform)
//        {
//            Destroy(t.gameObject);
//        }
//        DrawInventory();

//    }
//    public void DrawInventory()
//    {
//        foreach (InventorySystem.InventoryItem item in InventorySystem.current.inventory)
//        {
//            AddInventorySlot(item);
//        }
//    }

//    public void AddInventorySlot(InventorySystem.InventoryItem item)
//    {
//        GameObject obj = Instantiate(m_slotPrefab);
//        obj.transform.SetParent(transform, false);
//        SlotScript slot = obj.GetComponent<SlotScript>();
//        slot.Set(item);
//    }
//}



























using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;

    private InventorySystem inventorySystem;

    private void Start()
    {
        inventorySystem = InventorySystem.current;
        inventorySystem.onInventoryChangedEvent += UpdateUI;
        UpdateUI(); // Initial UI update
    }

    private void UpdateUI()
    {
        DrawInventory();
    }

    private void DrawInventory()
    {
        // Clear existing slots if any
        //ClearInventorySlots();

        // Instantiate new slots for each inventory item
        foreach (InventorySystem.InventoryItem item in inventorySystem.inventory)
        {
            AddInventorySlot(item);
        }
    }

    private void ClearInventorySlots()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void AddInventorySlot(InventorySystem.InventoryItem item)
    {
        GameObject slotObject = Instantiate(slotPrefab, transform);
        SlotScript slot = slotObject.GetComponent<SlotScript>();
        if (slot != null)
        {
            slot.Set(item);
        }
        else
        {
            Debug.LogError("SlotScript component not found on instantiated object.");
        }
    }
}

























//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InventoryUI : MonoBehaviour
//{
//    public GameObject m_slotPrefab;
//    // Start is called before the first frame update
//    void Start()
//    {
//        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
//        /*OnUpdateInventory();*/ // Initial update of inventory UI
//    }

//    private void OnUpdateInventory()
//    {

//        foreach (Transform t in transform)
//        {
//            Destroy(t.gameObject);
//        }
//        DrawInventory();
//    }

//    //private void ClearInventorySlots()
//    //{
//    //    foreach (Transform child in transform)
//    //    {
//    //        Destroy(child.gameObject);
//    //    }
//    //}

//    private void DrawInventory()
//    {
//        foreach (InventorySystem.InventoryItem item in InventorySystem.current.Inventory)
//        {
//            AddInventorySlot(item);
//        }
//    }

//    private void AddInventorySlot(InventorySystem.InventoryItem item)
//    {
//        GameObject obj = Instantiate(m_slotPrefab);
//        obj.transform.SetParent(transform, false);
//        SlotScript slot = obj.GetComponent<SlotScript>();
//        slot.Set(item);

//    }
//}
