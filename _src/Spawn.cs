using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform spawnPos;

    void Start()
    {
        playerTransform.position = new Vector3(spawnPos.position.x, playerTransform.position.y, spawnPos.position.z);
    }

}
