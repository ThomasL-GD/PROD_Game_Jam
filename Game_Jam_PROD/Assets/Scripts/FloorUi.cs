using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloorUi : MonoBehaviour
{
    static public FloorUi UI_Floor;

    void Start()
    {
        UI_Floor = GetComponent<FloorUi>();
        UpdateFloorUI();
    }

    // Update is called once per frame
    public void UpdateFloorUI()
    {
        GetComponent<TextMeshProUGUI>().text = $"Floor : {SpawnController.m_playerFloor}";
    }


}
