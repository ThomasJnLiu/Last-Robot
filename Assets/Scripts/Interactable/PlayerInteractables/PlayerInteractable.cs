using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteractable : Interactable
{
    // Control prompt to display based on state
    public string offPrompt;
    public string onPrompt;
    public string brokenPrompt;


    // Player body part required to fix interactable object
    public PlayerController.Parts partToFix;
    public int partsToFixCount;
    public PlayerController.Parts partsToUse;
    public int partsToUseCount; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = interactableTag;
        gameObject.layer = 7;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
* Get control prompt for interactable based on its state
*/
    public string GetControlPrompt()
    {
        switch (state)
        {
            case State.Off:
                return offPrompt;
            case State.On:
                return onPrompt;
            default:
                return brokenPrompt;
        }
    }

    public override void Fix(GameObject actor)
    {
        PlayerController player = actor.GetComponent<PlayerController>();

        if (state == State.Broken && player.canFix)
        {
            if (player.UsePartToFix(partToFix, partsToFixCount))
            {
                state = State.Off;
            }
        }
    }
}
