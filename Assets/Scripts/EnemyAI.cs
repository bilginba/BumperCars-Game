using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    Rigidbody rb;
    public NavMeshAgent agent;
    //[SerializeField] Transform bumperCar;
    GameObject[] bumperCars;

    public LayerMask whatIsGround, whatIsBumperCar;

    // Patrolling
    public Vector3 walkPoint;
    bool isWalkPointSet;
    public float walkPointRange;

    // States
    public float sightRange;
    public bool bumperCarInSightRange;

    private void Awake()
    {
        bumperCars = GameObject.FindGameObjectsWithTag("BumperCar");
        //bumperCar = GameObject.FindGameObjectWithTag("BumperCar").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    void Update()
    {
        bumperCarInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsBumperCar);

        if (!bumperCarInSightRange) Patrolling();
        else ChaseCar();
    }
    private void Patrolling()
    {
        if (!isWalkPointSet)
        {
            SearchWalkpoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


    }

    private void SearchWalkpoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            isWalkPointSet = true;
        }
    }

    private void ChaseCar()
    {
        Transform bumperCar = FindNearestCar();
        agent.destination = bumperCar.position;
        transform.LookAt(bumperCar.transform);
    }

    private Transform FindNearestCar()
    {
        float minDistance = 9999;
        Transform nearestCar = bumperCars[0].transform;
        foreach(GameObject car in bumperCars)
        {
            float distanceToCar = Vector3.Distance(transform.position, car.transform.position);
            if (transform.position == car.transform.position) continue;
            if (distanceToCar < minDistance)
            {
                minDistance = distanceToCar;
                nearestCar = car.transform;
            }
        }
        return nearestCar;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }



}
