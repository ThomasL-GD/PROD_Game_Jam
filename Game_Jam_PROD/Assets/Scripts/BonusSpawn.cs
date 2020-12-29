using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0,2);
        if (x != 0) Destroy(gameObject);
        Destroy(this);
    }
}
