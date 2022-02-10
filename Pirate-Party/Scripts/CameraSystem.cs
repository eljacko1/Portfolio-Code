using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public static CameraSystem Instance { get; private set; }

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private float minZoomDistance;
    [SerializeField] private float maxZoomDistance;
    [SerializeField] private float smoothing = 0.5f;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private List<Transform> targets = new List<Transform>();
    private Vector3 velocity;
    private Vector3 initialPosition;

    

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        if(targets.Count == 0) { return; }

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        //transform.LookAt(centerPoint);

        Transform camera = Camera.main.transform;
        Vector3 toTarget = centerPoint -  camera.position;

        // This constructs a rotation looking in the direction of our target,
        Quaternion targetRotation = Quaternion.LookRotation(toTarget);

        // This blends the target rotation in gradually.
        // Keep sharpness between 0 and 1 - lower values are slower/softer.
        float sharpness = 1f;
        camera.rotation = Quaternion.Lerp(camera.rotation, targetRotation, sharpness);

        // This gives an "stretchy" damping where it moves fast when far
        // away and slows down as it gets closer. You can also use 
        // Quaternion.RotateTowards() to get a more consistent speed.

    }

    private void Zoom()
    {
        float greatestDistance = GetGreatestDistance();

        if(greatestDistance < minZoomDistance) { greatestDistance = 0f; }

        float newZ = Mathf.Lerp(minZ, maxZ, greatestDistance / maxZoomDistance);
        float newX = Mathf.Lerp(minX, maxX, greatestDistance / maxZoomDistance);

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, newX, Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, newZ, Time.deltaTime));
    }

    private float GetGreatestDistance()
    {
        Bounds bounds = EncapsulateTargets();

        return bounds.size.x > bounds.size.z ? bounds.size.x : bounds.size.z;
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = EncapsulateTargets();
        Vector3 center = bounds.center;

        return center;
    }

    private Bounds EncapsulateTargets()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        foreach(Transform target in targets)
        {
            bounds.Encapsulate(target.position);
        }
        return bounds;
    }
}
