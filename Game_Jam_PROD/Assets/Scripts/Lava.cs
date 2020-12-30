using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] float m_rizeSpeed = 3;
    [SerializeField] float m_maxDistanceFromPlayer = 20;
    [SerializeField] float m_speedRaisePerFloor = 0.1f;
    [SerializeField] float m_maxSpeed = 7;

    [SerializeField] float m_speed = 0;

    static public float m_lavaY = 0;

    void Update()
    {
        if(m_speed != m_maxSpeed) m_speed = m_rizeSpeed + m_speedRaisePerFloor * SpawnController.m_playerFloor;

        if (transform.position.y < PlayerController.m_playerPosition.position.y) transform.Translate(Vector3.up * m_speed * Time.deltaTime);
        else transform.Translate(Vector3.up * m_rizeSpeed * Time.deltaTime);

        if (transform.position.y < PlayerController.m_playerPosition.position.y - m_maxDistanceFromPlayer)
        {
            transform.position = new Vector3(transform.position.x, PlayerController.m_playerPosition.position.y - m_maxDistanceFromPlayer, transform.position.z);
        }

         m_lavaY = transform.position.y;

        if (PlayerController.m_playerPosition.position.y <= transform.position.y-0.7f) CanvasTaint.m_inLava = true;
        else CanvasTaint.m_inLava = false;

        if (m_speed > m_maxSpeed) m_speed = m_maxSpeed;
    }
}
