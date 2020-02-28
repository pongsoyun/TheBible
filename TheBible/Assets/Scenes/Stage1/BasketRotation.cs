using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketRotation : MonoBehaviour
{
    JointMotor2D motor;
    HingeJoint2D hingeJoint2D;

    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        motor = hingeJoint2D.motor;
        if(hingeJoint2D.jointAngle >= hingeJoint2D.limits.max - 1)
        {
            motor.motorSpeed *= -1;
        }
        else if(hingeJoint2D.jointAngle <= hingeJoint2D.limits.min + 1)
        {
            motor.motorSpeed *= -1;
        }
        hingeJoint2D.motor = motor;
    }
}