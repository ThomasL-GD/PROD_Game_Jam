using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public static GameObject m_go = null;

    void Start()
    {
        m_go = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(0);
        }
    }

}
