using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] float m_rotateSpeed = 200f;
    [SerializeField] Vector3 m_spawnRotation = Vector3.zero;

    void Start()
    {
        transform.rotation = Quaternion.Euler(m_spawnRotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, m_rotateSpeed * Time.deltaTime);
    }
}
