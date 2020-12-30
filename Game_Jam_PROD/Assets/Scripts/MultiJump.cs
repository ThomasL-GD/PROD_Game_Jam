using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJump : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 10000;

    static public int m_jumps = 0;
    int m_availlableJumps = 0;

    PlayerJump m_playerJump = null;

    // Start is called before the first frame update
    void Start()
    {
        m_availlableJumps = m_jumps;
        m_playerJump = GetComponent<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_availlableJumps != m_jumps && m_playerJump.m_isGrounded)
        {
            m_availlableJumps = m_jumps;
        }

        if(!m_playerJump.m_isGrounded && Input.GetButtonDown("Jump") && m_availlableJumps!= 0)
        {
            m_playerJump.Jump(m_jumpForce);
        }
    }
}
