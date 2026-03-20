using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public HingeJoint2D joint;
    
    [SerializeField] private float currentAngle;
    public float motorSpeed;
    [SerializeField] private bool isLeftFlipper;
    
    public KeyCode flipperKey;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();

    }
    
    // Update is called once per frame
    void Update()
    {
        currentAngle = joint.jointAngle;
        if (Input.GetKey(flipperKey))
        {
            ApplyMotor(motorSpeed, true);

        }
        else if (!Input.GetKey(flipperKey))
        {
            ApplyMotor(-motorSpeed, false);
        }
        

        
    }

    private void ApplyMotor(float speed, bool isMovingForward)
    {
        if (!isLeftFlipper)
        {
            if (isMovingForward == true && currentAngle <= joint.limits.max)
            {
                JointMotor2D motor = joint.motor;
                motor.motorSpeed = speed;
                joint.motor = motor;
                
            }

            else if (isMovingForward == false && currentAngle >= joint.limits.min)
            {
                JointMotor2D motor = joint.motor;
                motor.motorSpeed = speed;
                joint.motor = motor;
               
            }

            else
            {
                return;
            }
        }
        else if (isLeftFlipper)
        {
            if (isMovingForward == false && currentAngle <= joint.limits.max)
            {
                JointMotor2D motor = joint.motor;
                motor.motorSpeed = -speed;
                joint.motor = motor;
                Debug.Log("APPLYING MOTOR WITH " + speed);
                Debug.Log("Moving Forward is " + isMovingForward);
            }

            else if (isMovingForward == true && currentAngle >= joint.limits.min)
            {
                JointMotor2D motor = joint.motor;
                motor.motorSpeed = -speed;
                joint.motor = motor;
                Debug.Log("APPLYING MOTOR WITH " + speed);
                Debug.Log("Moving Forward is " + isMovingForward);
            }

            else
            {
                return;
            }
        }
        
        
        
       
        

    }

}
