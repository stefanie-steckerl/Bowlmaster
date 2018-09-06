﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public int lastStandingCount = -1;
    public float distanceToRaise = 40f;

    private Ball ball;
    private bool ballEnteredBox = false;
    private float lastChangeTime;

    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

        standingDisplay.text = CountStanding().ToString();
        if(ballEnteredBox){
            CheckStanding();
        }

    }

    public void RaisePins (){
        // Raise standing pins only distanceToRaise
        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {

            if (pin.isStanding())
            {
                pin.transform.Translate (new Vector3 (0, distanceToRaise, 0));
            }
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering pins");
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
    }

    void CheckStanding()
    {
        // Update lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount){
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled
        if((Time.time - lastChangeTime) > settleTime){ // If last change > 3 seconds ago
            PinsHaveSettled();
        } 
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1; // Indicates pins have settled and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        // Ball enters play box
        if(thingHit.GetComponent<Ball>()){
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;


        //Figure out whether pins exited the play area and then destroy them
        if(thingLeft.GetComponent<Pin>()){
            Destroy(thingLeft);
        }
    }

    int CountStanding(){
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){

            if(pin.isStanding()){
                standing++;
            }
        }

        return standing;
    }


}

