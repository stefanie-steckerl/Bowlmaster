using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]

public class BallDragLaunch : MonoBehaviour {
    
    private Ball ball;
    public float startTime, endTime;
    public Vector3 dragStart, dragEnd;
    private float dragDuration;


	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void DragStart(){
        //Capture time and position of drag start
            startTime = Time.time;
            dragStart = Input.mousePosition;
    }

    public void DragEnd()
    {
        //Launch the ball
        endTime = Time.time;
        dragEnd = Input.mousePosition;
        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);

    }

    public void MoveStart(float nudge)
    {
        if(!ball.inPlay) {
        ball.transform.Translate(new Vector3(nudge,0,0));
        }
    }

}
