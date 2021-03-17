using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public enum Parts {
        Arm,
        Leg,
        Head,
        Torso,
        None
    }

    public PlayerInteractable interactable;
    private Dictionary<Parts, int> partsLeft;

    public bool canInteract;
    public bool isInteracting;

    public bool canFix;
    public bool usedPartToFix;

    public int armsLeft;

    // Start is called before the first frame update
    void Start()
    {
        partsLeft = new Dictionary<Parts, int>();
        partsLeft.Add(Parts.Arm, 2);
        partsLeft.Add(Parts.Leg, 2);
        partsLeft.Add(Parts.Head, 1);
        partsLeft.Add(Parts.Torso, 1);

        // box.transform.SetParent(this.transform, true);
        ResetInteractable(null);

        // Subscribe to interactable enter event
        PlayerInteractRaycast.OnContextEnter += SetInteractable;
        PlayerInteractRaycast.OnContextExit += ResetInteractable;
    }

    void OnDestroy() {
        Debug.Log("Oh No!");
        PlayerInteractRaycast.OnContextEnter -= SetInteractable;
        PlayerInteractRaycast.OnContextExit -= ResetInteractable;
    }

    // Update is called once per frame
    void Update()
    {

        partsLeft.TryGetValue(Parts.Arm, out armsLeft);

        if (interactable) {
            if (isInteracting) {
                canFix = false;
                canInteract = true;
            } else {
                canFix = (interactable.partToFix != Parts.None && HasRemaining(interactable.partToFix) >= interactable.partToFixCount);
                canInteract = (interactable.partToUse != Parts.None && HasRemaining(interactable.partToUse) >= interactable.partToUseCount);
            }
        }
    }

    public void SetInteractable(PlayerInteractable ic) {
        interactable = ic;
    }

    public void ResetInteractable(PlayerInteractable ic) {
        interactable = null;
        isInteracting = false;
        canFix = false;
        canInteract = false;
    }

    private int HasRemaining(Parts parts) {
        int remaining = 0;
        partsLeft.TryGetValue(parts, out remaining);
        return remaining;
    }

    public bool UsePart(Parts part, int count) {
        if (canFix) {
            partsLeft[part] -= count;
            usedPartToFix = true;
            canFix = false;
            return true;
        }

        return false;
    }

    public bool ReturnPart(Parts part, int count) {
        if (usedPartToFix) {
            partsLeft[part] += count;
            usedPartToFix = false;
            canFix = true;
            return true;
        }

        return false;
    }
}
