using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] GameObject[] m_towerTiles = null;
    [SerializeField] [Tooltip("En nombre de tuiles")] float m_hauteurDeTours = 8;
    [SerializeField] [Tooltip("En Mettres")] float m_hauteurDeTuiles = 6;

    [SerializeField] Vector3[] m_towerRoots = null;

    public static int m_playerFloor = 0;
    int m_floorTracker = 0;

    public static float m_unloadDistanceY = 0;
    // Start is called before the first frame update

    void Start()
    {
        for (int i=0;  i< m_towerRoots.Length; i++)
        {
            for (int j = 0; j < m_hauteurDeTours; j++)
            {
                int random = Random.Range(0, m_towerTiles.Length);
                Instantiate(m_towerTiles[random], m_towerRoots[i] + new Vector3(0, j* m_hauteurDeTuiles, 0), Quaternion.Euler(-90, 45 * Random.Range(0,9), 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float math  =(PlayerController.m_playerPosition.position.y - m_hauteurDeTuiles/2) / m_hauteurDeTuiles;
        m_playerFloor = (int)math;

        if(m_floorTracker < m_playerFloor)
        {
            m_floorTracker = m_playerFloor;

            for (int i = 0; i < m_towerRoots.Length; i++)
            {
                int random = Random.Range(0, m_towerTiles.Length);
                Instantiate(m_towerTiles[random], m_towerRoots[i] + new Vector3(0, (m_floorTracker + m_hauteurDeTours - 1) * m_hauteurDeTuiles , 0), Quaternion.Euler(-90, 45 * Random.Range(0, 8), 0));
            }
        }
    }
}