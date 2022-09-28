using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    Camera MainCamera;
    public Camera Cam2;
    public Camera Cam3;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.enabled = true;
        Cam2.enabled = false;
        Cam3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (MainCamera.enabled)
            {
                Cam2.enabled = true;
                Cam3.enabled = false;
                MainCamera.enabled = false;
            }
            else if (!MainCamera.enabled)
            {
                if (Cam2.enabled)
                {
                    Cam2.enabled = false;
                    Cam3.enabled = true;
                    MainCamera.enabled = false;
                }
                else if (!Cam2.enabled)
                {
                    Cam2.enabled = false;
                    Cam3.enabled = false;
                    MainCamera.enabled = true;
                }
            }
        }
    }
}
