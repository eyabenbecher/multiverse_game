//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class SlotScript : MonoBehaviour
//{
//    // Start is called before the first frame update
//    [SerializeField]
//    private Image m_icon;

//    [SerializeField]
//    private TextMeshProUGUI m_label;

//    [SerializeField]
//    private GameObject m_stackObj;

//    [SerializeField]
//    private TextMeshProUGUI m_stacklabel;

//    public void Set(InventoryItem item)
//    {
//        m_icon.sprite = item.data.icon;
//        m_label.text = item.data.displayName;

//        if(item.stackSize<=1 )
//        {
//            m_stackObj.SetActive(false);
//            return;
//        }

//        m_stacklabel.text = item.stackSize.ToString();
//    }
//}
