using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public Transform m_playerPosition = null;

    [SerializeField] float m_speed = 5f;
    [SerializeField] float m_gravityMultiplier = 5f;

    Rigidbody m_rb = null;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * m_gravityMultiplier;

        m_playerPosition = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = Vector3.Normalize(transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * m_speed;

        m_rb.velocity = new Vector3(v.x, m_rb.velocity.y, v.z);
    }
}
