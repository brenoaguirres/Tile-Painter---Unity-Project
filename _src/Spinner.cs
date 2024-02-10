using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        Vector3 rotationVector = Vector3.up * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationVector);     
    }
}
