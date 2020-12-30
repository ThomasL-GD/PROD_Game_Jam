using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float m_healthStart = 100;
    [SerializeField] [Tooltip("in seconds")] float m_healthRegenCooldownDelay = 3.0f;
    [SerializeField] [Tooltip("in HP per seconds")] float m_healthRegenRate = 10.0f;

    float m_regenCooldown = 0;
         
    bool m_startedRegen = false;
    bool m_startcountdown = false;

    static public float m_health = 0;
    static public float m_maxHealth = 0;

    float m_healthIncrements = 0.1f;
    RectTransform m_rectangle = null;
    // Start is called before the first frame update
    void Start()
    {
        m_regenCooldown = m_healthRegenCooldownDelay;
        m_health = m_healthStart;
        m_maxHealth = m_healthStart;
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

        if(!m_startedRegen && m_health != m_maxHealth && !CanvasTaint.m_inLava && !m_startcountdown)
        {
            m_startcountdown = true;
        }

        if (m_startcountdown)
        {
            m_regenCooldown -= Time.deltaTime;
            if (m_regenCooldown <=0)
            {
                m_startedRegen = true;

                m_regenCooldown = m_healthRegenCooldownDelay;
                m_startcountdown = false;
            }
        }

        if (m_startedRegen)
        {
            m_health += m_healthRegenRate * Time.deltaTime;

            if(m_health >= m_maxHealth)
            {
                m_health = m_maxHealth;
                m_startedRegen = false;
            }
        }
    }
}
