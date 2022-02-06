using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public static bool GameRadar = false;
    public GameObject radarUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameRadar)
            {
                radarUI.SetActive(false);
                GameRadar = false;
            }
            else
            {
                radarUI.SetActive(true);
                GameRadar = true;
            }
        }
    }
}
