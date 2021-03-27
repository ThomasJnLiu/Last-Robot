using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualChange : MonoBehaviour
{
    public enum bodyStates {full, oneArm, fullHold};
    int totalStates = 3;
    private GameObject arm;
    
    Animator animator;

    bodyStates previousState;
    public static bodyStates currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        previousState = bodyStates.full;
        currentState = bodyStates.full;
        arm = GameObject.Find("GAR_Arms");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (previousState == currentState){return;}

        arm.SetActive(true);
        if (currentState == bodyStates.oneArm)
        {
            arm.SetActive(false);
        }
        
        animator.SetInteger("BodyState", (int)currentState);
        previousState = currentState;

    }

}
