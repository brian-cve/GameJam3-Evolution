using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicles : MonoBehaviour
{
    private float speed = 30.0f;
    private float leftBound = -320.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        

    }
}
