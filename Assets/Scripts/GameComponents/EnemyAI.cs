
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/*
 * Car movement is not working properly.  
 */
public class EnemyAI : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField] float carSpeed; 
    [SerializeField] float carDistanceToGround = 0f; // distance to check grounded
    [SerializeField] float wanderTime; 
    [SerializeField] float carDestroyPoint = -2f; // destroy threshold

    public BoxCollider boxCollider;
    bool canMove = false;
    public Transform nearestCar = null;

    public GameObject[] bumperCars;
    //float carDistanceThreshold = 1f;

    void Start()
    {
        bumperCars = GameObject.FindGameObjectsWithTag("BumperCar");
        rb = GetComponent<Rigidbody>();
        carDistanceToGround = boxCollider.bounds.extents.y;
    }
    /*
     * Checks if the car is grounded to move
     */
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, carDistanceToGround + 0.1f);
    }

    void Update()
    {
        // If the car is below destroy threshold the object gets destroyed
        if(transform.position.y <= carDestroyPoint)
        {
            DestroyCars.instance.DecreaseCarCount();
            Destroy(gameObject);
        }
        if (IsGrounded())
        {
            if (nearestCar == null) // If there are no cars near the object, it wanders
            {
                if(wanderTime > 0)
                {
                    canMove = true;
                    wanderTime -= Time.deltaTime;
                }
                else
                {
                    canMove = false;
                    wanderTime = Random.Range(5.0f, 15.0f);
                    ChangeDirection();
                    canMove = true;
                }
            }
            else
            {
                canMove = false;
                ChaseCar();
                canMove = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddForce(transform.forward * carSpeed, ForceMode.Acceleration); // car moves to faced direction
        }
    }

    /*
     * Changes the direction of the car
     */
    void ChangeDirection()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
    /*
     * Chase car when it gets into the detect range
     */
    private void ChaseCar()
    {
        //Transform bumperCar = FindNearestCar();
        transform.LookAt(nearestCar.transform);
        transform.position = Vector3.MoveTowards(this.transform.position, nearestCar.position - new Vector3(1f, 0f, 1f), carSpeed * Time.deltaTime);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BumperCar" && nearestCar == null)
        {
            nearestCar = other.gameObject.transform;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BumperCar" && nearestCar == null)
        {
            nearestCar = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BumperCar")
        {
            nearestCar = null;
        }
    }

    // Prior car selection method
    /*
    private Transform FindNearestCar()
    {
        float minDistance = 9999;
        foreach (GameObject car in bumperCars)
        {
            if (car == null) continue;
            if (car.name == this.transform.name) continue;
            float distanceToCar = Vector3.Distance(transform.position, car.transform.position);
            if (distanceToCar < minDistance && distanceToCar > carDistanceThreshold)
            {
                minDistance = distanceToCar;
                nearestCar = car.transform;
            }
        }
        return nearestCar;
    }
    */


}
