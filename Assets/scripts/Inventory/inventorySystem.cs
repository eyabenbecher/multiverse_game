using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    public event Action onInventoryChangedEvent;





    private void Awake()
    {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem item))
        {
            return item;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
        //onInventoryChangedEvent?.Invoke();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
        //onInventoryChangedEvent?.Invoke();

    }

    [Serializable]
    public class InventoryItem
    {
        public InventoryItemData data { get; private set; }
        public int stackSize { get; private set; }

        public InventoryItem(InventoryItemData source)
        {
            data = source;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }


    }


}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InventorySystem : MonoBehaviour
//{
//    public static InventorySystem current;

//    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
//    public List<InventoryItem> Inventory;
//    public event Action onInventoryChangedEvent;

//    private void Awake()
//    {
//        current = this;
//        Inventory = new List<InventoryItem>();
//        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
//    }

//    public InventoryItem Get(InventoryItemData referenceData)
//    {
//        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem item))
//        {
//            return item;
//        }
//        return null;
//    }

//    public void Add(InventoryItemData referenceData)
//    {
//        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
//        {
//            value.AddToStack();
//        }
//        else
//        {
//            InventoryItem newItem = new InventoryItem(referenceData);
//            Inventory.Add(newItem);
//            m_itemDictionary.Add(referenceData, newItem);
//        }
//        StartCoroutine(UpdateInventoryUI());
//    }

//    public void Remove(InventoryItemData referenceData)
//    {
//        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
//        {
//            value.RemoveFromStack();
//            if (value.stackSize == 0)
//            {
//                Inventory.Remove(value);
//                m_itemDictionary.Remove(referenceData);
//            }
//        }
//        StartCoroutine(UpdateInventoryUI());
//    }

//    IEnumerator UpdateInventoryUI()
//    {
//        yield return null; // Wait for one frame to ensure UI updates correctly
//        onInventoryChangedEvent?.Invoke();
//    }

//    [Serializable]
//    public class InventoryItem
//    {
//        public InventoryItemData data;
//        public int stackSize;

//        public InventoryItem(InventoryItemData source)
//        {
//            data = source;
//            AddToStack();
//        }

//        public void AddToStack()
//        {
//            stackSize++;
//        }

//        public void RemoveFromStack()
//        {
//            stackSize--;
//        }
//    }
//}
