using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetection : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Box"){
            player.GetGrabTaget(other.gameObject);
            player.canGrab = true;
        }

        if (other.gameObject.tag == "BrokenArm") {
            player.GetFixTarget(other.gameObject);
            player.canFix = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Box"){
            player.canGrab = false;
        }

        if (other.gameObject.tag == "BrokenArm") {
            player.canFix = false;
        }
    }
}
