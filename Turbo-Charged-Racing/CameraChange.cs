using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChange : MonoBehaviour
{
    public GameObject normalCamera;
    public GameObject farCamera;
    public GameObject firstPersonCamera;

    public int cameraMode;
    public bool cameraPressed;

    public void OnCameraChange(InputAction.CallbackContext context)
    {
        cameraPressed = context.ReadValueAsButton();


        if (cameraPressed)
        {
            if (cameraMode == 0)
            {
                cameraMode = 2;
            }
            else
            {
                cameraMode -= 1;
            }

            StartCoroutine(ModeChange());
        }
    }

    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (cameraMode == 0)
        {
            normalCamera.SetActive(true);
            firstPersonCamera.SetActive(false);
        }
        if (cameraMode == 1)
        {
            farCamera.SetActive(true);
            normalCamera.SetActive(false);
        }
        if (cameraMode == 2)
        {
            firstPersonCamera.SetActive(true);
            farCamera.SetActive(false);
        }
    }
}
