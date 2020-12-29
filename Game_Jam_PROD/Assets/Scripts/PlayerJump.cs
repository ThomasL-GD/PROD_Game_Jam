using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 100;

    Rigidbody m_rb = null;

    [SerializeField] float m_maxGroundDistance = 3f;
    bool isGrounded = false;
    
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded) Jump(m_jumpForce);
    }

    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, m_maxGroundDistance);
    }

    public void Jump(float p_jumpForce)
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, 0, m_rb.velocity.z);
            m_rb.AddForce(new Vector3(0, p_jumpForce, 0));
        }
    }
}
