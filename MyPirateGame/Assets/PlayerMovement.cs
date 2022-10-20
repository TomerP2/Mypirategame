using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;

    public Rigidbody2D rb;

    public float speed;
    public float rotation;

    // Update is called once per frame
    void Update(){
        // Input
        rotation = Input.GetAxisRaw("Horizontal");
        speed = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        // Movement
        rb.rotation += rotation * rotationSpeed * -1 * Time.deltaTime;
        transform.position += transform.up * speed * moveSpeed * Time.deltaTime;
    }
}
