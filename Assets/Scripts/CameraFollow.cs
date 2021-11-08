using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + new Vector3(0, 0, -10) + Vector3.ClampMagnitude(Camera.main.ScreenToWorldPoint(Input.mousePosition),50); //add mouse position to target position bias
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
