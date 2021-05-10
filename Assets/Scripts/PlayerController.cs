using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody rb;
    [SerializeField] float carFwdSpeed = 0f;
    [SerializeField] float carRevSpeed = 0f;
    [SerializeField] float carTurnSpeed = 0f;
    public Transform steeringWheel;
    private Vector3 inputMoveVector;

    [NonSerialized] public bool isRightPressed = false;
    [NonSerialized] public bool isLeftPressed = false;
    [NonSerialized] public bool isAccelerated = false;
    [NonSerialized] public bool isReverse = false;
    [NonSerialized] public bool isBumped = false;

    private float newRotation = 0f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementInputHandler();
        ChangeCarRotation();
        ChangeSteeringWheelRotation();
        
    }
    private void FixedUpdate()
    {
        if (isAccelerated)
        {
            rb.AddForce(transform.forward * carFwdSpeed, ForceMode.Acceleration);
            //rb.velocity = inputMoveVector * carFwdSpeed;
        }
        if (isReverse)
        {
            rb.AddForce(transform.forward * -carRevSpeed, ForceMode.Acceleration);
            //rb.velocity = inputMoveVector * -carRevSpeed;
        }
    }

    private void MovementInputHandler()
    {
        if (isRightPressed && !isLeftPressed)
        {
            inputMoveVector = new Vector3(1.0f, 0.0f, 1.0f);
        }
        else if (isLeftPressed && !isRightPressed)
        {
            inputMoveVector = new Vector3(-1.0f, 0.0f, 1.0f);
        }
        else
        {
            inputMoveVector = new Vector3(0.0f, 0.0f, 1.0f);
        }
    }

    private void ChangeCarRotation()
    {
        if (isReverse)
            inputMoveVector.x *= -1;
        float newRotation = inputMoveVector.x * carTurnSpeed * Time.deltaTime * inputMoveVector.z;
        transform.Rotate(0f, newRotation, 0f, Space.World);
    }

    private void ChangeSteeringWheelRotation()
    {
        steeringWheel.eulerAngles = new Vector3(steeringWheel.eulerAngles.x, steeringWheel.eulerAngles.y, newRotation);
    }

    
}
