using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] [Range(-2,2)] float m_rotateSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, m_rotateSpeed, 0);
    }
}
