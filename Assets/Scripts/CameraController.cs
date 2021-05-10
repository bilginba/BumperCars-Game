using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    public Transform target;

    [SerializeField]
    private Vector3 initialOffset;

    private Vector3 currentOffset;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (target == null)
        {
            Debug.LogError("Assign a target for the camera in Unity's inspector");
        }

        currentOffset = initialOffset;
    }

    void LateUpdate()
    {
        
        /*
        transform.position = target.position + currentOffset;
        
        float turnAngle = PlayerController.instance.inputMoveVector.x * PlayerController.instance.turnSpeed * Time.deltaTime;
        if (!Mathf.Approximately(turnAngle, 0f))
        {
            transform.RotateAround(target.position, Vector3.up, turnAngle);
            currentOffset = transform.position - target.position;
        }
       
        */
        
    }
}
