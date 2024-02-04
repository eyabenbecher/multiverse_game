//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InventoryUI : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public void Start()
//    {
//        inventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
//    }

//    private void OnUpdateInventory()
//    {
//        foreach(Transform t in transform)
//        {
//            Destroy(t.gameObject);
//        }
//        DrawInventory();
//    }
//    public void DrawInventory()
//    {
//        foreach (InventoryItem item in inventorySystem.current.inventory)
//        {
//            AddInventorySlot(item);
//        }   
//    }

//    public void AddInventorySlot()
//    {
//        GameObject obj = Instantiate(m_slotPrefab);
//        obj.transform.SetParent(transform, false);

//        UIInventoryItemSlot slot = obj.GetComponent<UIInventoryItemSlot>();
//        slot.Set(item);
//    }



//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
