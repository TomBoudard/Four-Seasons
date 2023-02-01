using MyNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MyNamespace.move;

public class CameraUpdate : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    GameObject player;
    void Start()
    {
        // Main camera activated
        // UI camera containing the menu deactivated
        camera1.enabled = true;
        camera2.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (camera2.enabled)
        {
            // Stop the cube from doing anything when accessing the menu
            player.GetComponent<move>().player_movement = false;
        }
        else
        {
            player.GetComponent<move>().player_movement = true; 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Change camera, go to menu or not
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}
