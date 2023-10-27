using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERAFacePlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset, zoomOffset;
    [SerializeField] Vector2 zoomFOV;
    [SerializeField] private float speed;

    bool useZoomOffset = false;
    Camera cam;

    private void Awake() => cam = GetComponent<Camera>();

    private void Update()
    {
        if (!target) { return; }
        transform.position = Vector3.Lerp(transform.position, target.position + ((useZoomOffset) ? zoomOffset : offset), Time.deltaTime / speed);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, (useZoomOffset) ? zoomFOV.y : zoomFOV.x, Time.deltaTime / speed);
        transform.LookAt(target);
    }
}