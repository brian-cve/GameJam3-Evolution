using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 15f;

    void Update() {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
