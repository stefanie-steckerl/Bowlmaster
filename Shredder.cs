using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shredder : MonoBehaviour {

    public Text standingDisplay;
    private bool ballEnteredBox = false;


    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        // Ball enters play box
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;


        //Figure out whether pins exited the play area and then destroy them
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

}
