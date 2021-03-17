using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlsContext : MonoBehaviour
{
    // Status
    public bool isDisabled {get; private set; }

    // Context Out
    private Text text;
    
    // Player scripts
    private PlayerController player;
    public PlayerInteraction playerInteraction;
    private PlayerInteractable playerInteractable;

    private void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;

        // Get player scripts
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();
        playerInteraction = playerObject.GetComponent<PlayerInteraction>();

        PlayerInteractRaycast.OnContextEnter += RegisterInteractable;
        PlayerInteractRaycast.OnContextExit += RemoveInteractable;
    }

    void OnDestroy() {
        Debug.Log("Oh No!");
        PlayerInteractRaycast.OnContextEnter -= RegisterInteractable;
        PlayerInteractRaycast.OnContextExit -= RemoveInteractable;
    } 

    private void Update() {
        text.text = "";
        if (text.enabled && playerInteractable) {
            (bool canItemBeUsed, string usePrompt, bool canItemBeFixed, string fixPrompt) = playerInteractable.GetControlPrompt();
            if (canItemBeFixed) {
                text.text = "Press F to " + fixPrompt;
                if (playerInteraction.isInteracting || !(playerInteraction.canFix || playerInteraction.usedPartToFix)) {
                    text.text += " (Disabled)";
                }
                text.text += "\n";
            }

            if (canItemBeUsed) {
                text.text += "Press E to " + usePrompt;
                if (!playerInteraction.canInteract) {
                    text.text += " (Disabled)";
                }
            }
        }
    }

    /**
     * Set control based on context and extrinsic variables.
     * Returns true if context state is enabled; else false
     **/
    public void RegisterInteractable(PlayerInteractable interactable)
    {
        text.enabled = true;
        playerInteractable = interactable;
        // context = GetContextFromTag(obj.tag);
    }

    /**
     *  Disable controls context when the object leaves the player's context
     **/
    public void RemoveInteractable(PlayerInteractable interactable)
    {
        text.enabled = false;
        playerInteractable = null;
    }
}
