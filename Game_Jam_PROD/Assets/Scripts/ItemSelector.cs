using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    [SerializeField] RectTransform[] m_position = null;

    RectTransform m_currentPosition = null;
    public static int m_currentSelectionIndex = 0;


    void Start()
    {
        m_currentPosition = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(Input.GetAxis("Scroll") > 0f)
        {
            m_currentSelectionIndex++;

            if (m_currentSelectionIndex == m_position.Length) m_currentSelectionIndex = m_position.Length-1;
            m_currentPosition.position = m_position[m_currentSelectionIndex].position;
        }
        else if (Input.GetAxis("Scroll") < 0f)
        {
            m_currentSelectionIndex--;

            if (m_currentSelectionIndex == -1) m_currentSelectionIndex = 0;

            m_currentPosition.position = m_position[m_currentSelectionIndex].position;
        }

        if (Input.GetButtonDown("Destroy"))
        {
            Inventory.m_inventory.DestroyItem(m_currentSelectionIndex);
        }
    }
}
