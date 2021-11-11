using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        Cursor.visible = false;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.position = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
