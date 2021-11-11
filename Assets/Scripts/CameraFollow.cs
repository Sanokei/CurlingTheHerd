using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Camera cam;
    public float smoothing = 5f;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + new Vector3(0, 0, -10) + Vector3.ClampMagnitude(cam.ScreenToWorldPoint(Input.mousePosition),25); //add mouse position to target position bias
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
