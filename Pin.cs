using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    //public float standingThreshold = 6f;


    void Start()
    {
        // Use this for initialization

    }

    void Update()
    {
        // Update is called once per frame
      

    }

    public bool isStanding()
    {
        // Ignore the Y axis (twist) of the pin, only falling (X/Z) axes by splitting the
        // rotation quaternion into X,Y,Z and scaling out the Y axis (multiply by 1,0,1)
        Vector3 eulerWithoutTwist = Vector3.Scale(transform.rotation.eulerAngles, new Vector3(1, 0, 1));

        // Create a quaternion to store the rotation without the twist
        Quaternion rotationWithoutTwist = Quaternion.Euler(eulerWithoutTwist);

        // Get the angle between pin's rotation and world's "up"

        float tiltAngle = Quaternion.Angle(rotationWithoutTwist, Quaternion.identity);

        return (tiltAngle >= 87f && tiltAngle <= 92f );

    }


    //This is the initial method that was taught in the class, but which did not work!
    //public bool isStanding() {
    //Vector3 rotationInEuler = transform.rotation.eulerAngles;
    //float tiltInX = Mathf.Abs(rotationInEuler.x);
    //float tiltInZ = Mathf.Abs(rotationInEuler.z);

    //if (90 - tiltInX < standingThreshold && tiltInZ > standingThreshold)
    //   {
    // return true;
    // }
    // else {
    // return false;
    // }
    // }

}
