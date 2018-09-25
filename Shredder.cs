using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shredder : MonoBehaviour {

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
