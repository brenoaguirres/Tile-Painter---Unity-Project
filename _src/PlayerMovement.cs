using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Cached Components
    private Rigidbody myRigidbody;

    // Variables
    [SerializeField] private float moveSpeed = 10f;
    private float initialMoveSpeed;
    private Vector3 playerMovement;

    void Awake() {
        myRigidbody = GetComponent<Rigidbody>(); 
        initialMoveSpeed = moveSpeed;   
    }

    void Start()
    {
        playerMovement = new Vector3(0, 0, 0);
    }

    void Update() 
    {
        GetMovementVector3();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetMovementVector3()
    {
        float xVel = Input.GetAxis("Horizontal");
        float zVel = Input.GetAxis("Vertical");
        playerMovement = new Vector3(xVel, 0, zVel).normalized * moveSpeed * Time.fixedDeltaTime;
    }

    private void MovePlayer()
    {
        myRigidbody.MovePosition(transform.position + playerMovement);
    }

    public void SetMoveSpeed(float value) {
        moveSpeed = value;
    }
    
    public float GetMoveSpeed() {
        return initialMoveSpeed;
    }

    public void ResetMoveSpeed() {
        moveSpeed = initialMoveSpeed;
    }
}
