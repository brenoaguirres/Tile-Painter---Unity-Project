using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopePlayerMovement : MonoBehaviour
{
    // Cached Components
    private Rigidbody myRigidbody;

    // Variables
    [SerializeField] private float moveSpeed = 10f;
    private float initialMoveSpeed;
    private Vector3 playerMovement;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        initialMoveSpeed = moveSpeed;
    }

    void Start()
    {
        playerMovement = new Vector3(0, 0, 0);
    }

    void Update()
    {
        GetGyroMovementVector3(); // Use gyroscope input for movement
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetGyroMovementVector3()
    {
        // Check if the device supports gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            // Get gyroscope input
            Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

            // Convert gyroscope input to movement
            playerMovement = new Vector3(gyroInput.x, 0, gyroInput.y) * moveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Gyroscope not supported on this device.");
            playerMovement = Vector3.zero; // Stop movement if gyroscope is not available
        }
    }

    private void MovePlayer()
    {
        myRigidbody.MovePosition(transform.position + playerMovement);
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public float GetMoveSpeed()
    {
        return initialMoveSpeed;
    }

    public void ResetMoveSpeed()
    {
        moveSpeed = initialMoveSpeed;
    }
}