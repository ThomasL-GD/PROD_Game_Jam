using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRespawn : MonoBehaviour
{
    [SerializeField] float m_minY = -10;

    [SerializeField] float[] m_checkpointsX = null;
    [SerializeField] Vector3[] m_respawnSpot = null;

    int m_index = 0;
    // Update is called once per frame
    void Update()
    {
        for (int i = m_index; i< m_checkpointsX.Length; i++)
        {
            if (transform.position.x >= m_checkpointsX[i]) m_index = i;
        }

        if (transform.position.y < m_minY) transform.position = m_respawnSpot[m_index];
    }
}
