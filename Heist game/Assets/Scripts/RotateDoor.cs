using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed = 50;
    void Update()
    {
        //rotates rotating door
        transform.Rotate(0, 0, speed * Time.deltaTime);
        
    }
}
