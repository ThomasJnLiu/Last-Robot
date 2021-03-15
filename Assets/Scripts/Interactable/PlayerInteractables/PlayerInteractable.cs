using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteractable : Interactable
{
    // Control prompt to display based on state
    public string offPrompt;
    public string onPrompt;
    public string brokenPrompt;
    public string fixedPrompt;
    public bool wasInitiallyBroken;


    // Player body part required to fix interactable object
    public PlayerInteraction.Parts partToFix;
    public int partToFixCount;
    public PlayerInteraction.Parts partToUse;
    public int partToUseCount; 

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
    public (bool, string, bool, string) GetControlPrompt()
    {
        switch (state)
        {
            case State.Off:
                return (true, offPrompt, wasInitiallyBroken, fixedPrompt);
            case State.On:
                return (true, onPrompt, false, "");
            default:
                return (false, "", true, brokenPrompt);
        }
    }

    public override bool Fix(GameObject actor)
    {
        PlayerInteraction player = actor.GetComponent<PlayerInteraction>();

        if (state == State.Broken && player.canFix)
        {
            return player.UsePart(partToFix, partToFixCount);
        }

        return false;
    }

    public override bool UnFix(GameObject actor)
    {
        PlayerInteraction player = actor.GetComponent<PlayerInteraction>();

        if (state == State.Off && partToFix != PlayerInteraction.Parts.None && player.usedPartToFix)
        {
            return player.ReturnPart(partToFix, partToFixCount);
        }

        return false;
    }
}
