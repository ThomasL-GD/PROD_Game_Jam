using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] ClassBonus[] m_bonusPrefabs = null; 

    // Update is called once per frame
    void Start()
    {
        List<int> prefabs = new List<int>();

        for (int i = 0; i< m_bonusPrefabs.Length; i++)
        {
            if(m_bonusPrefabs[i].m_spawnFloor <= SpawnController.m_playerFloor)
            {
                prefabs.Add(i);
            }
        }

        int rand = Random.Range(0, prefabs.Count);
        Instantiate(m_bonusPrefabs[prefabs[rand]].m_gameObject, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
