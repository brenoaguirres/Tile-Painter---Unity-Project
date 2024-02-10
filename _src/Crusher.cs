using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    // Variables
    [SerializeField] private float timeToMove = 2f;
    [SerializeField] private float timeToReset = 2f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float resetMoveSpeed = 4f;
    private Vector3 initialPosition;
    [SerializeField] private Transform moveTransform;
    private Vector3 movePosition;
    private float timer;
    private float resetTimer;
    private bool canMove = false;
    private bool canReset = false;

    // Components
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            canReset = false;

        if(Vector3.Distance(transform.position, movePosition) <= 0.1f)
            resetTimer -= Time.fixedDeltaTime;

        if (resetTimer <= 0) {
            canReset = true;
            resetTimer = timeToReset;
        }

        if(canReset && Vector3.Distance(transform.position, initialPosition) >= 0.1f) {
            Move(initialPosition, resetMoveSpeed);
            timer = timeToMove;
        }
    }

    void SkillCooldown() {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0) {
            canMove = true;
        }
    }
}
