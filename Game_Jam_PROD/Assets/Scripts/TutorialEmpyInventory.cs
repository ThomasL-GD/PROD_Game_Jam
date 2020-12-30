using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEmpyInventory : MonoBehaviour
{
    [SerializeField] Inventory m_inventory = null;

    void OnTriggerEnter()
    {
        for (int i = 0; i < m_inventory.m_inventoryStorage.Length; i++)
        {
            m_inventory.m_inventoryStorage[i] = null;
        }

        m_inventory.InventoryUpdate();

        Destroy(this);
    }
}
