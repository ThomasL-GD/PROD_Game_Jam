using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] ClassBonus[] m_bonusPrefabs = null; 

    // Update is called once per frame
    void Start()
    {
        while (true)
        {
            int rand = Random.Range(0, m_bonusPrefabs.Length);
            if (m_bonusPrefabs[rand].m_spawnFloor <= SpawnController.m_playerFloor) {

                Instantiate(m_bonusPrefabs[rand].m_gameObject, transform.position, transform.rotation);
                break;
            }
        }
        Destroy(gameObject);
    }
}
