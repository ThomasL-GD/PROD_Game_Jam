using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTiles : MonoBehaviour
{
    static float m_destroyDistanceY = 50;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + m_destroyDistanceY < PlayerController.m_playerPosition.transform.position.y) Destroy(gameObject);
        if (PlayerController.m_playerPosition.transform.position.y < Lava.m_lavaY - 50) Debug.Log("Game Over");
    }
}
