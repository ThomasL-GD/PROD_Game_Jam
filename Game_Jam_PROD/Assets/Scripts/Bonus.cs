using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] public Sprite m_uiSprite = null;
    [SerializeField] public bool m_canLevelUp = true;
    [SerializeField] public GameObject m_LevelUpItem = null;
    [SerializeField] public float m_destroyJumpForce = 900000;

    [SerializeField] public int m_level = 0;

    [SerializeField] int m_jumpAdd = 0;
    [SerializeField] float m_jumpHeightBoostPercent = 0;
    [SerializeField] float m_speedBoostPercent = 0;
    [SerializeField] float m_healthBoostPercent = 0;
    [SerializeField] int m_spawnChance = 2;


    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, m_spawnChance);
        if (x != 0) Destroy(gameObject);
    }

    public void ApplyEffect()
    {
        if (m_jumpAdd != 0)
        {
            if (MultiJump.m_jumps < m_jumpAdd) MultiJump.m_jumps = m_jumpAdd;
        }

        if (m_jumpHeightBoostPercent != 0)
        {
            if (PlayerJump.m_script.m_jumpForce < PlayerJump.m_script.m_jumpForceBase * (1 + m_jumpHeightBoostPercent / 100)) PlayerJump.m_script.m_jumpForce = PlayerJump.m_script.m_jumpForceBase * (1 + m_jumpHeightBoostPercent / 100);
        }

        if (m_speedBoostPercent != 0) {
            if (PlayerController.m_script.m_speed < PlayerController.m_script.m_baseSpeed * (1 + m_speedBoostPercent / 100)) PlayerController.m_script.m_speed = PlayerController.m_script.m_baseSpeed * (1 + m_speedBoostPercent / 100);
        }

        if (m_healthBoostPercent != 0){
            if (HealthBar.m_maxHealth < HealthBar.m_maxHealth * (1 + m_healthBoostPercent / 100)) HealthBar.m_maxHealth = HealthBar.m_maxHealth * (1 + m_healthBoostPercent / 100);
        }
    }
}
