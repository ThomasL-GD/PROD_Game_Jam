using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float m_healthStart = 100;

    static public float m_health = 0;

    float m_healthIncrements = 0.1f;
    RectTransform m_rectangle = null;
    // Start is called before the first frame update
    void Start()
    {
        m_health = m_healthStart;
        m_healthIncrements = 0.5f / m_health;
        m_rectangle = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health <= 0)
        {
            m_health = 0;
            GetComponent<RectTransform>().localScale = Vector3.zero;
            Debug.Log("Game Over");
        } else {
            GetComponent<RectTransform>().localScale = new Vector3(m_health * m_healthIncrements * Mathf.Sqrt(2*m_health) * 0.05f, m_rectangle.localScale.y, m_rectangle.localScale.z);
        }
    }
}
