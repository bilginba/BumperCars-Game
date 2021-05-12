using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCarBounce : MonoBehaviour
{
    [SerializeField] float bounceValue;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BumperCar")
        {
            rb.AddForce(collision.GetContact(0).normal * bounceValue, ForceMode.Impulse);
            if (gameObject.name != "PlayerBumperCar"){
                gameObject.GetComponent<EnemyAI>().nearestCar = gameObject.GetComponent<EnemyAI>().bumperCars[Random.Range(0, (int)DestroyCars.instance.totalEnemyCars)].transform;
            }
        }
    }
}
