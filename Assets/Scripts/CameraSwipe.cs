using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 originalRot;

    public float rotationSpeed = 0.5f;
    public float dir = -1;
    void Start()
    {
        originalRot = cam.transform.eulerAngles;
        rotX = originalRot.x;
        rotY = originalRot.y;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                //swipe
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
