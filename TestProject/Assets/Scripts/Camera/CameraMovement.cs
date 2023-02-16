using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject CameraPivot;
    private Vector3 playerPos;
    private Vector3 cameraPos;
    private Vector3 cameraTranslate;
    private Transform playerTrans;
    private Transform CameraTrans;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Player and Camera objects
        player = GameObject.FindGameObjectWithTag("Player");
        CameraPivot = GameObject.FindGameObjectWithTag("CameraPivot");

        // Initialize the position of the elements
        playerTrans = player.transform;
        playerPos = playerTrans.position;
        CameraTrans = CameraPivot.transform;
        cameraPos = CameraTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Change Camera position if player position has changed
        cameraTranslate.z = playerTrans.position.z - playerPos.z;
        float denom = (float) Math.Cos(-CameraTrans.rotation.eulerAngles.z) * 3;
        cameraTranslate.x = (playerTrans.position.x - playerPos.x) / denom;
        denom = (float) Math.Cos(90 + CameraTrans.rotation.eulerAngles.z) * 3;
        cameraTranslate.y = (playerTrans.position.x - playerPos.x) / denom;

        CameraPivot.transform.Translate(cameraTranslate);
        playerTrans = player.transform;
        playerPos = playerTrans.position;
        CameraTrans = CameraPivot.transform;
        cameraPos = CameraTrans.position;
    }
}
