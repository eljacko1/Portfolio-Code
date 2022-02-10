using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    InputMaster input;
    private float scrollValue;
    private Vector3 offset;
    public float offsetMagnitude;
    float targetZoom;
    float camSpeed;

    Transform target;
    bool freeCamera = true;

    [SerializeField] float scrollMin;
    [SerializeField] float scrollMax;
    void Start()
    {
        input = new InputMaster();
        input.Player.CameraZoom.performed += x => scrollValue = x.ReadValue<float>()/120;
        input.Player.CameraZoom.canceled += x => scrollValue = 0;
        input.Player.Enable();

        offset = (transform.position - player.transform.position).normalized;
        target = player.transform;
    }


    private void Update()
    {
        if (freeCamera)
        {
            targetZoom -= scrollValue;
            targetZoom = Mathf.Clamp(targetZoom, scrollMin, scrollMax);
        }
    }

    void FixedUpdate()
    {
         offsetMagnitude = Mathf.SmoothDamp(offsetMagnitude, targetZoom, ref camSpeed, 5f * Time.deltaTime);
         transform.position = target.position + offset * offsetMagnitude;
    }

    public void SetTarget(Transform newTarget)
    {
        freeCamera = false;
        target = newTarget;
        targetZoom += 1;
    }

    public void ResetTarget()
    {
        freeCamera = true;
        target = player.transform;
        targetZoom -= 1;
    }
    
}

