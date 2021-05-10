using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCarBounce : MonoBehaviour
{
    [SerializeField] float bounceValue;
    Rigidbody rb;
    bool isBouncing = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BumperCar")
        {
            rb.AddForce(collision.contacts[0].normal * bounceValue, ForceMode.Impulse);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }
        
    }
    void StopBounce()
    {
        isBouncing = false;
    }
}
