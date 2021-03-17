using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Interactable : MonoBehaviour
{
    public enum State
    {
        Off,
        On,
        Broken
    }

    // Tag for context detection
    public string interactableTag;

    // Interactable state
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = interactableTag;
    }

    public abstract bool Use(GameObject actor);

    public abstract bool Reset(GameObject actor);

    public abstract bool Fix(GameObject actor);

    public abstract bool UnFix(GameObject actor);

    public void Interact(GameObject actor)
    {
        switch (state)
        {
            case State.Off:
                if (Use(actor))
                    state = State.On;
                break;
            case State.On:
                if (Reset(actor))
                    state = State.Off;
                break;
        }
    }

    public void FixUnfix(GameObject actor)
    {
        switch (state)
        {
            case State.Broken:
                if (Fix(actor))
                {
                    state = State.Off;
                    PlayerVisualChange.currentState = PlayerVisualChange.bodyStates.oneArm;
                }
                break;

            case State.Off:
                if (UnFix(actor))
                {
                    state = State.Broken;
                    PlayerVisualChange.currentState = PlayerVisualChange.bodyStates.full;
                }
                break;
        }
    }
}
