using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableScript : MonoBehaviour {
    public enum State {
        Off,
        On,
        Broken
    }

    // Tag for context detection
    public string interactableTag;

    // Interactable state
    public State state;

    // Control prompt to display based on state
    public string offPrompt;
    public string onPrompt;
    public string brokenPrompt;

    // Player body part required to fix interactable object
    public bool? partToFix;
    
    // Start is called before the first frame update
    void Start() {
        gameObject.tag = interactableTag;
        gameObject.layer = 7;
    }

    // Update is called once per frame
    void Update() {
        
    }

    /*
    * Get control prompt for interactable based on its state
    */
    public string GetControlPrompt() {
        switch (state) {
            case State.Off:
                return offPrompt;
            case State.On:
                return onPrompt;
            default:
                return brokenPrompt;
        }
    }
}
