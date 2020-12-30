using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public Transform m_playerPosition = null;
    static public PlayerController m_script = null;
    [SerializeField] public float m_baseSpeed = 5f;
    [SerializeField] float m_gravityMultiplier = 5f;

    public float m_speed = 0;

    Rigidbody m_rb = null;

    // Start is called before the first frame update
    void Start()
    {
        m_script = this;
        m_speed = m_baseSpeed;
        m_rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-9.8f,0) * m_gravityMultiplier;

        m_playerPosition = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = Vector3.Normalize(transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * m_speed;

        m_rb.velocity = new Vector3(v.x, m_rb.velocity.y, v.z);
    }
}
