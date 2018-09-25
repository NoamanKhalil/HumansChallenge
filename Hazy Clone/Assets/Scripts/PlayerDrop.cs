using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{


    Rigidbody rb;
    bool isGrounded;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            rb.velocity = Vector3.zero;
            rb.mass = 10;
            rb.AddForce(Vector3.down * 100);
            //Debug.Log("FALLING DOWN");
        }
        else
        {
            rb.mass = 5;
            //rb.AddForce(Vector3.down);
        }

    }


}
