using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float force = 45f;
    public float spinSpeed = 5f;
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //Assignment 3 added dirty flag
        if(!SwitchEditor.isPlaying)
        {
            if (rb.angularVelocity.z < spinSpeed)
            {
                rb.AddTorque(transform.forward * force * Time.deltaTime);
            }
            else if((spinSpeed < 0) && (rb.angularVelocity.z > spinSpeed))
            {
                rb.AddTorque(transform.forward * force * Time.deltaTime);
            }
        }
    }
}
