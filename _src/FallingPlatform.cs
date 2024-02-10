using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Variables
    [SerializeField] private float timeToMove = 0.75f;
    [SerializeField] private float timeToReset = 2f;
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float resetMoveSpeed = 10f;
    private Vector3 initialPosition;
    [SerializeField] private Transform moveTransform;
    private Vector3 movePosition;
    private float timer;
    private float resetTimer;
    private bool canMove = false;
    private bool canReset = false;
    private bool hasPlayerCrossed = false;

    // Components
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        timer = timeToMove;
        resetTimer = timeToReset;
        initialPosition = GetComponent<Transform>().position;
        movePosition = moveTransform.position;
    }


    void FixedUpdate()
    {
        SkillCooldown();
        MoveToTarget();
        ResetPosition();
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Player"))
            hasPlayerCrossed = true;
    }

    void Move(Vector3 target, float speed) {
        Vector3 movementVector = (target - transform.position).normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movementVector);    
    }

    void MoveToTarget(){
        if(Vector3.Distance(transform.position, movePosition) <= 0.1f) {
            canMove = false;
        }

        if (canMove) {
            Move(movePosition, moveSpeed);
        }
    }

    void ResetPosition() {
        if(Vector3.Distance(transform.position, initialPosition) <= 0.1f)
        {
            canReset = false;
        }

        if(Vector3.Distance(transform.position, movePosition) <= 0.1f)
            resetTimer -= Time.deltaTime;

        if (resetTimer <= 0) {
            canReset = true;
            resetTimer = timeToReset;
            hasPlayerCrossed = false;
        }

        if(canReset && Vector3.Distance(transform.position, initialPosition) >= 0.1f) {
            Move(initialPosition, resetMoveSpeed);
            timer = timeToMove;
        }
    }

    void SkillCooldown() {
        if (hasPlayerCrossed) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0) {
            canMove = true;
        }
    }
}
