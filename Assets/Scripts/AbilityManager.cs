using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityManager : MonoBehaviour
{
    public static Dictionary<string, string> bodyAbilityPairs = new Dictionary<string, string>();
    public JumpAbility jumpAbility;
    public WalkAbility walkAbility;
    public LiftAbility liftAbility;

    private bool isArmDisabled;
    private bool isDisabledArmUsed;

    public Text controls;
    public Text extras;

    public PlayerController player;
    public BluePlatform bluePlatform;

    public TextMesh statusIndicator;

    // Start is called before the first frame update
    void Start()
    {
        isArmDisabled = false;
        isDisabledArmUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            if (isArmDisabled && !isDisabledArmUsed) {
                isArmDisabled = false;

                String prompt = controls.text;
                prompt = prompt.Replace("Assemble", "Disassemble");
                prompt = prompt.Replace("C: Lift (Disabled)", "C: Lift");
                prompt = prompt.Replace("E: Fix Broken Lever with Arm", "E: Fix Broken Lever with Arm (Disabled)");
                controls.text = prompt;
                prompt = extras.text;
                prompt = prompt.Replace("Arm", "None");
                extras.text = prompt;

                liftAbility.enabled = true;

            } else if (!isArmDisabled) {
                isArmDisabled = true;
                String prompt = controls.text;
                prompt = prompt.Replace("Disassemble", "Assemble");
                prompt = prompt.Replace("C: Lift", "C: Lift (Disabled)");
                prompt = prompt.Replace("E: Fix Broken Lever with Arm (Disabled)", "E: Fix Broken Lever with Arm");
                controls.text = prompt;

                prompt = extras.text;
                prompt = prompt.Replace("None", "Arm");
                extras.text = prompt;

                liftAbility.enabled = false;
            }
        }

        if (Input.GetKeyDown("e")) {
            if (isArmDisabled && !isDisabledArmUsed && player.canFix) {
                isDisabledArmUsed = true;

                String prompt = controls.text;
                prompt = prompt.Replace("Assemble", "Assemble (Disabled)");
                prompt = prompt.Replace("E: Fix Broken Lever with Arm", "E: Use Lever");
                prompt = prompt.Replace("F: Retrieve Arm (Disabled)", "F: Retrieve Arm");
                controls.text = prompt;

                prompt = extras.text;
                prompt = prompt.Replace("Arm", "None");
                extras.text = prompt;

                prompt = statusIndicator.text;
                prompt = prompt.Replace("(Broken: Arm missing)", "(Fixed: G.A.R.M)");
                statusIndicator.text = prompt;

            } else if (isArmDisabled && isDisabledArmUsed && player.canFix) {
                liftAbility.enabled = false;
                bluePlatform.active = true;
            }
        }

        if (Input.GetKeyDown("f")) {
            if (isArmDisabled && isDisabledArmUsed && player.canFix) {
                isDisabledArmUsed = false;

                String prompt = controls.text;
                prompt = prompt.Replace("Assemble (Disabled)", "Assemble");
                prompt = prompt.Replace("E: Use Lever", "E: Fix Broken Lever with Arm");
                prompt = prompt.Replace("F: Retrieve Arm", "F: Retrieve Arm (Disabled)");
                controls.text = prompt;

                prompt = extras.text;
                prompt = prompt.Replace("None", "Arm");
                extras.text = prompt;

                prompt = statusIndicator.text;
                prompt = prompt.Replace("(Fixed: G.A.R.M)", "(Broken: Arm missing)");
                statusIndicator.text = prompt;
            }
        }
    }
}
