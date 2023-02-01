using MyNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static MyNamespace.move;


public class dashscroll : MonoBehaviour
{
    private Scrollbar[] scrollbars;
    private Scrollbar scrollbar;
    private GameObject dash;

    private void Start()
    {
        // Get the Player Gameobject
        dash = GameObject.FindGameObjectWithTag("Player");

        // Find all scrollbars 
        scrollbars = Scrollbar.FindObjectsOfType<Scrollbar>();
        for (int i = 0; i<scrollbars.Length; ++i)
        {
            // Select the right scrollbar
            if (scrollbars[i].tag == "DashScrollbar")
            {
                scrollbar = scrollbars[i];
            }
        }
    }
    void Update()
    {
        // Get the dash components from the Player
        float global_time_dash = dash.GetComponent<move>().global_time_for_dash;
        float time_dash = dash.GetComponent<move>().time_dash;

        // Update scrollbar 
        if (global_time_dash < time_dash)
        {
            scrollbar.value = 1 - global_time_dash / time_dash;
        }
        if (global_time_dash > time_dash)
        {
            scrollbar.value = 0;
        }
    }

}
