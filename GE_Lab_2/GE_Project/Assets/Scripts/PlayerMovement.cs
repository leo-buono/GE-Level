using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultiplier = 5f;
    public float jumpForce = 10f;
    Rigidbody rb;

    bool isFalling = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    //Used so that we can move in diagonals and combine movement and stuff like that
    Vector3 currentMovement;
    // Update is called once per frame
    void Update()
    {
        //Done this way to support diagonal movement
        currentMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            currentMovement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentMovement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentMovement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentMovement += Vector3.right;
        }    
        rb.velocity = new Vector3(currentMovement.x * speedMultiplier, rb.velocity.y, currentMovement.z * speedMultiplier);  
        if(Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFalling = true;
        }
        //TODO: player rotation which should rotate the camera as well
        if(Input.GetKey(KeyCode.Q))
        {
            //transform.rotation;
        }
    } 
    void OnCollisionStay()
    {
        isFalling = false;
    }
    // void OnCollisionExit()
    // {
    //     isFalling = true;
    // }
}
