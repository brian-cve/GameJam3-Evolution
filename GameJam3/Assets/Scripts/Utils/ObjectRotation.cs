using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 15f;
    public bool isTargeted = false;

    void Update() {
        if (!isTargeted)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void setIsTargeted(bool newState) {
        this.isTargeted = newState;
    }
}
