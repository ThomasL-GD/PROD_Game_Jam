using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRespawn : MonoBehaviour
{
    [SerializeField] float m_minY = -10;
    [SerializeField] Vector3 m_respawnSpot = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < m_minY) transform.position = m_respawnSpot;
    }
}
