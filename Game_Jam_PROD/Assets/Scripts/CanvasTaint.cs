using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTaint : MonoBehaviour
{
    [SerializeField] Color m_defaultColor = Color.white;
    [SerializeField] Color m_lavaColor = Color.red;

    public static bool m_inLava = false;
    Image m_UILavaTaint = null;

    void Start()
    {
        m_UILavaTaint = GetComponent<Image>();
    }

    void Update()
    {
        if (m_inLava && m_UILavaTaint.color != m_lavaColor) m_UILavaTaint.color = m_lavaColor;
        if (!m_inLava && m_UILavaTaint.color != m_defaultColor) m_UILavaTaint.color = m_defaultColor;
    }
}
