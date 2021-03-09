using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlsContext : MonoBehaviour
{
    // Status
    public bool isDisabled {get; private set; }
    public Context context { get; private set; }

    // Context Out
    private Text text;

    /**
     * Three different contexts
     **/
    public enum Context
    {
        Box,
        Broken_Lever,
        Lever,
        None
    }

    private void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;

        // Initial
        isDisabled = false;
        context = Context.None;
    }

    /**
     * Get context based on the tag that the player is near
     **/
    Context GetContextFromTag(string tag)
    {
        switch (tag)
        {
            case "Box":
                return Context.Box;

            case "Broken_Lever":
                return Context.Broken_Lever;

            case "Lever":
                return Context.Lever;
            
            default:
                return Context.None;
        }
    }

    /**
     * Get prompt text based on context
     **/
    string GetContextText(Context context)
    {
        switch (context)
        {
            case Context.Box:
                return "Pick up box";

            case Context.Broken_Lever:
                return "Disassemble arm to fix lever";

            case Context.Lever:
                return "Pull lever";
            // None
            default:
                return "";
        }
    }

     

    /**
     * Set control based on context and extrinsic variables.
     * Returns true if context state is enabled; else false
     **/
    public void AddContextFromTag(string tag)
    {
        text.enabled = true;
        text.text = GetContextText(GetContextFromTag(tag));
    }

    /**
     *  Disable controls context when the object leaves the player's context
     **/
    public void DisableControlsContext()
    {
        text.enabled = false;
    }

    /**
     * Set whether the controls are allowed
     **/
    public void SetControlsContextAbility(bool isEnabled)
    {
        isDisabled = isEnabled;
    }
}
