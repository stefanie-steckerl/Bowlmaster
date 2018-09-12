﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public int lastStandingCount = -1;
    public GameObject pinSet;

    private bool ballEnteredBox = false;
    private Ball ball;
    private float lastChangeTime;

    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update () {

        standingDisplay.text = CountStanding().ToString();
        if(ballEnteredBox){
            UpdateStandingCountAndSettle();
        }

    }

    public void RaisePins (){

        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
           pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
        {
        Debug.Log("Lowering pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){            
            pin.Lower();
        }

    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        Instantiate(pinSet, new Vector3(0, 0, 1829), Quaternion.identity);
    }

    void UpdateStandingCountAndSettle()
    {
        // Update lastStandingCount
        // Call PinsHaveSettled() when they have settled
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

