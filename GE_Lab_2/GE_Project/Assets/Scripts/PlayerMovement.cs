using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultiplier = 5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speedMultiplier;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity = Vector3.back * speedMultiplier;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity = Vector3.left * speedMultiplier;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity = Vector3.right * speedMultiplier;
        }     
    } 
}
