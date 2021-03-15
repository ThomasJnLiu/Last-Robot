using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : PlayerInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Pick up the box. Assume that it's possible. The checking SHOULD happen in ControlsContext
     */
    public override void Use(GameObject actor)
    {
        PlayerController player = actor.GetComponent<PlayerController>();

        transform.SetParent(player.transform, true);
        transform.position = (player.transform.forward *5f) + player.transform.position;
        transform.localRotation = Quaternion.Euler(0,0,0);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        state = State.On;
    }

    public override void Reset(GameObject actor)
    {
        transform.SetParent(null, true);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;

        state = State.Off;
    }
}
