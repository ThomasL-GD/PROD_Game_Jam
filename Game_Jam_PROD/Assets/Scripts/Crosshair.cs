using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    [SerializeField]
    Sprite m_defaultReticule = null;

    [SerializeField]
    Sprite m_interactReticule = null;

    Image m_img;

    void Start()
    {
        m_img = GetComponent<Image>();
    }
    
    void Update()
    {
        if (CameraFirstPersonLook.m_canInteract && m_img.sprite != m_interactReticule) {
            m_img.sprite = m_interactReticule;
        }else if (!CameraFirstPersonLook.m_canInteract && m_img.sprite != m_defaultReticule)
        {
            m_img.sprite = m_defaultReticule;
        }
    }
}