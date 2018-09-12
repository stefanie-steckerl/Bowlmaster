using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float distanceToRaise = 40f;
    public Rigidbody rigidBody;

    //private float standingThreshold = 3f;

    void Start()
    {
        // Use this for initialization
        rigidBody = GetComponent<Rigidbody>();
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

    public void RaiseIfStanding(){
    if (isStanding())
            {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            }
    }


    public void Lower()
    {
        if (isStanding())
        {
            transform.Translate(new Vector3(0, 0, 0), Space.World);
            rigidBody.useGravity = true;
        }
    }
}
