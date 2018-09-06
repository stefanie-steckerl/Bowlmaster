using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;
    private Vector3 offset;
    private float endPosition;

	// Use this for initialization
	void Start () {
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        endPosition = ball.transform.position.z;
        if (endPosition <= 1829f)
       {
            transform.position = ball.transform.position + offset;
        }
	}
}
