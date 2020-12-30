using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevel : MonoBehaviour
{
    [SerializeField] int m_inventorySlot=0;

    GameObject m_object = null;

    int m_level = 0;

    void Update()
    {
        if(Inventory.m_inventory.m_inventoryStorage[m_inventorySlot] != null && m_object != Inventory.m_inventory.m_inventoryStorage[m_inventorySlot]) m_object = Inventory.m_inventory.m_inventoryStorage[m_inventorySlot];
        
        if (m_object != null && m_level != m_object.GetComponent<Bonus>().m_level)
        {
            m_level = m_object.GetComponent<Bonus>().m_level;
            UpdateText(m_level);
        }
        if (Inventory.m_inventory.m_inventoryStorage[m_inventorySlot] == null)
        {
            UpdateText(-1);
            m_level = -1;
        }
    }

    public void UpdateText(int p_level =0)
    {
        
        if(p_level == -1 ) GetComponent<TextMeshProUGUI>().text = " ";
        else GetComponent<TextMeshProUGUI>().text = $"{p_level}";
    }
}
