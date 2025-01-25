using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBalls : MonoBehaviour
{
    [SerializeField] private Transform rotator;
    [SerializeField] private float rotationSpeed = 10;

    void Update()
    {
        rotator.Rotate(0, 0, rotationSpeed*Time.fixedDeltaTime);
    }
}
