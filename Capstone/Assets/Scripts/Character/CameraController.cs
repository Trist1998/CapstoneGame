using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    private int cameraSelected = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C) && (!PauseMenu.paused))
        {
            cameras[cameraSelected].enabled = false;
            cameraSelected++;
            if (cameraSelected == cameras.Length)
                cameraSelected = 0;
            cameras[cameraSelected].enabled = true;
        }
    }
}
