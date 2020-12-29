using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] m_tiles = null;
    [SerializeField] int[] m_tileDifficultyMin = null;
    [SerializeField][Tooltip("0 for infinity")] int[] m_tileDifficultyMax = null;

    // Start is called before the first frame update
    void Start()
    {
        bool spawning = true;
        while (spawning)
        {
            int random = Random.Range(0, m_tiles.Length);
            if (m_tileDifficultyMin[random] <= SpawnController.m_playerFloor && (m_tileDifficultyMax[random] > SpawnController.m_playerFloor || m_tileDifficultyMax[random] == 0))
            {
                Instantiate(m_tiles[random], transform.position, Quaternion.Euler(-90, 45 * Random.Range(0, 9), 0));
                spawning = false;
                Destroy(gameObject);
            }
            
        }
    }
}
