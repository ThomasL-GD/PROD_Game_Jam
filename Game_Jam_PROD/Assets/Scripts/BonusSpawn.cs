﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] m_prefabs = null;

    public GameObject m_selectedPrefab = null;
    [SerializeField] public Sprite m_uiSprite = null;
    [SerializeField] public bool m_canLevelUp = true;
    [SerializeField] public GameObject m_LevelUpItem = null;
    [SerializeField] public float m_destroyJumpForce = 900000;
    
    [SerializeField] int m_jumpAdd = 0;
    [SerializeField] float m_jumpHeightBoostPercent = 0;
    [SerializeField] float m_speedBoostPercent = 0;
    [SerializeField] float m_healthBoostPercent = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0,2);
        if (x != 0) Destroy(gameObject);

        m_selectedPrefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
    }

    public void ApplyEffect()
    {
        if(m_jumpAdd != 0)MultiJump.m_jumps = m_jumpAdd;

        if (m_jumpHeightBoostPercent != 0) PlayerJump.m_script.m_jumpForce = PlayerJump.m_script.m_jumpForceBase * (1 + m_jumpHeightBoostPercent / 100);

        if (m_speedBoostPercent != 0) PlayerController.m_script.m_speed = PlayerController.m_script.m_baseSpeed * (1 + m_speedBoostPercent / 100);

        if (m_healthBoostPercent != 0) HealthBar.m_maxHealth = HealthBar.m_maxHealth * (1 + m_healthBoostPercent / 100);
    }
}
