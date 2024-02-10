using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Roller : MonoBehaviour
{
    // Components
    private Rigidbody rb;

    // Variables
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotSpeed = 10f;
    private Vector3 initialPos;
    [SerializeField] private Transform goalPos;
    private Vector3 destination;

    void Awake()
    {
        initialPos = transform.position; 
        destination = goalPos.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        BoulderMove();       
    }

    void BoulderMove() {
        Vector3 rotMovement = new Vector3(1, 0, 0) * rotSpeed * Time.deltaTime;
        transform.Rotate(rotMovement);
        Movement();
    }

    void Movement() {
        if(Vector3.Distance(transform.position, destination) >= 0.2f) {
            Vector3 walkMovement = (destination - transform.position) * moveSpeed * Time.deltaTime;
            rb.AddForce(walkMovement, ForceMode.VelocityChange);
        }
        else {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = initialPos;
        }
    }
}
