using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkers : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private List<Transform> positions = new List<Transform>();
    [SerializeField] private List<Vector3> destinations = new List<Vector3>();
    private int positionCount;
    private int currentPosition = 0;
    private int lastPosition = 0;

    private bool hasToChangePosition = false;
    [SerializeField] private float timeToChangePosition = 2;
    private float currentTimer;

    private Rigidbody rb;
    

    private void Start() {
        foreach (Transform p in positions) {
            destinations.Add(p.position);
        }

        positionCount = positions.Count;
        currentTimer = timeToChangePosition;
        rb = GetComponent<Rigidbody>();
        lastPosition = currentPosition;
    }

    private void FixedUpdate() {
        ChangePosition();
    }

    private void ChangePosition() {
        if (currentPosition == lastPosition) {
            if (currentTimer > 0)
                currentTimer -= Time.fixedDeltaTime;
            else {
                if (currentPosition < positionCount - 1)
                    currentPosition++;
                else
                    currentPosition = 0;
                currentTimer = timeToChangePosition;
            }
        }
        else {
            Vector3 movementDir = (destinations[currentPosition] - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
            transform.LookAt(destinations[currentPosition]);
            rb.MovePosition(transform.position + movementDir);
            if (Vector3.Distance(transform.position, destinations[currentPosition]) <= 1f)
                lastPosition = currentPosition;
        }
    }
}
