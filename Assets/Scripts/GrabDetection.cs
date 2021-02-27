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
            Debug.Log("Grab range in");
            player.GetGrabTaget(other.gameObject);
            player.canGrab = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Box"){
            Debug.Log("Grab range out");
            player.canGrab = false;
        }
    }
}
