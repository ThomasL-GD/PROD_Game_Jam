using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChooser : MonoBehaviour
{
    [SerializeField] Material[] m_materials = null;

    void Start()
    {
        //m_mat = GetComponent<MeshRenderer>().material;
        if (transform.position.x > 40) GetComponent<MeshRenderer>().material = m_materials[1];
        else if (transform.position.x < -40) GetComponent<MeshRenderer>().material = m_materials[2];
        else if (transform.position.z > 40) GetComponent<MeshRenderer>().material = m_materials[3];
        else if (transform.position.z < -40) GetComponent<MeshRenderer>().material = m_materials[4];
        else GetComponent<MeshRenderer>().material = m_materials[0];
    }
}
