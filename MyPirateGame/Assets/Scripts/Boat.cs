using System.Collections;
using System.Collections.Generic;
using Ditzelgames;
using UnityEngine;

public class Boat : MonoBehaviour
{

    //Visible properties
    public Transform Motor;
    public float steerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;
    
    //Used components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;


    public void Awake() {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() {
        //Default direction
        var forceDirection = transform.forward;
        var steer = 0;

        //Steer direction
        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;
        
        //Rotational force
        Rigidbody.AddForceAtPosition(steer * transform.right * steerPower / 100f, Motor.position);

        //Compute vectors
        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);

        //Forward backward power
        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);
    }
}
