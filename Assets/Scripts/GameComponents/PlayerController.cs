using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody rb;
    [SerializeField] float carFwdSpeed = 0f; // car forward speed
    [SerializeField] float carRevSpeed = 0f; // car reverse speed
    [SerializeField] float carTurnSpeed = 0f; // car turn speed
    public Transform steeringWheel; // steering wheel object
    [SerializeField] float steeringWheelMaxTurnAngle; // steering wheel turn limit
    [SerializeField] float carDestroyPoint = -2f; // destroy threshold
    private Vector3 inputMoveVector;

    [NonSerialized] public bool isRightPressed = false; 
    [NonSerialized] public bool isLeftPressed = false; 
    [NonSerialized] public bool isAccelerated = false;
    [NonSerialized] public bool isReverse = false;

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
        CheckToDestroy();
        MovementInputHandler();
        ChangeCarRotation();
        ChangeSteeringWheelRotation();
        
    }
    /*
     * If the car is below destroy threshold the object gets destroyed
     */
    private void CheckToDestroy()
    {
        if (transform.position.y <= -2.0f)
        {
            if (UIManager.instance.gameObjects.winPopUp.activeSelf == false)
            {
                UIManager.instance.gameObjects.gameOverPopUp.SetActive(true);
            }
        }
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

    /*
     * Handling Inputs for both Android and Editor
     */
    private void MovementInputHandler()
    {
#if UNITY_EDITOR
        inputMoveVector.x = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetMouseButtonDown(0)) isAccelerated = true;
        if (Input.GetMouseButtonUp(0)) isAccelerated = false;

        if (Input.GetMouseButtonDown(1)) isReverse = true;
        if (Input.GetMouseButtonUp(1)) isReverse = false;
#elif UNITY_ANDROID
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
#endif

    }
    /*
     * Changes car rotation based on car movement
     */
    private void ChangeCarRotation()
    {
        if (isReverse)
            inputMoveVector.x *= -1;
        float newRotation = inputMoveVector.x * carTurnSpeed * Time.deltaTime;
        transform.Rotate(0f, newRotation, 0f, Space.World);
    }

    /*
     * Changes steering wheel rotation based on car rotation
     */
    private void ChangeSteeringWheelRotation()
    {
        if (isReverse)
            inputMoveVector.x *= -1;
        steeringWheel.localEulerAngles = Vector3.back * Mathf.Clamp((inputMoveVector.x * 100), -steeringWheelMaxTurnAngle, steeringWheelMaxTurnAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CarDestroyer")
        {
            // Show GameOver Popup if Win Popup is not active
            if (UIManager.instance.gameObjects.winPopUp.activeSelf == false)  
            {
                UIManager.instance.gameObjects.gameOverPopUp.SetActive(true);
            }
        }

    }

    


}
