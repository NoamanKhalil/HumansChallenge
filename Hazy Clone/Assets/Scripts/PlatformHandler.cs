using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHandler : MonoBehaviour {

    public float jumpForce = 10f;

    public void fallPlatform()
    {
        Rigidbody rb;
        this.gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.mass = 10;
        GameManager.instance.addScore();

    }



    void OnCollisionEnter(Collision collision)
    {
        /*Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb!=null)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            fallPlatform();
        }*/


    }
}
