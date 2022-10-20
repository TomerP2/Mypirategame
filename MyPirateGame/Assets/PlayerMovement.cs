using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float acceleration = 0.005f;
    public float maxSpeed = 10f;

    public float rotationSpeed = 40f;

    public Rigidbody2D rb;

    private float currentSpeed = 0f;
    private float rotation;

    // Update is called once per frame
    void Update(){
        // Input
        rotation = Input.GetAxisRaw("Horizontal") * -1;
        if (Input.GetAxisRaw("Vertical") > 0){
            if (currentSpeed <= maxSpeed){
                currentSpeed += Input.GetAxisRaw("Vertical") * acceleration;
            }
        }
        if (Input.GetAxisRaw("Vertical")  < 0){
            if (currentSpeed > 0){
                currentSpeed += Input.GetAxisRaw("Vertical") * acceleration;
            }
        } 


    }

    void FixedUpdate() {
        // Movement
        rb.rotation += rotation * rotationSpeed * Time.deltaTime;
        transform.position += transform.up * currentSpeed * Time.deltaTime;
    }
}
