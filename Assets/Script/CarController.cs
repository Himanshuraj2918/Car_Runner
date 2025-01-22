using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider backLeftWheelCollider;

    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backRightWheelTransform;
    public Transform backLeftWheelTransform;

    float horizontalInput;
    float verticalInput;

    public float motorForce = 100f;
    public float maxSteeringAngle = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheel();
        GetInput();
        Steering();
    }

    void GetInput(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void MotorForce(){
        frontRightWheelCollider.motorTorque = motorForce * verticalInput  ;
        frontLeftWheelCollider.motorTorque = motorForce * verticalInput ;
    }

    void Steering(){
        frontRightWheelCollider.steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = maxSteeringAngle * horizontalInput;
    }

    void UpdateWheel(){
        RotateWheel(frontRightWheelCollider, frontRightWheelTransform);
        RotateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        RotateWheel(backRightWheelCollider, backRightWheelTransform);
        RotateWheel(backLeftWheelCollider, backLeftWheelTransform);
    }

    void RotateWheel(WheelCollider wheelCollider, Transform wheelTransform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
