using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualChange : MonoBehaviour
{
    public enum bodyStates {full, oneArm};
    int totalStates = 2;
    string[] modelNames = new string[2]{"WalkCycle (temp)(in place)", "GAR One Arm"};
    GameObject[] models;
    
    Animator animator;

    bodyStates previousState;
    public bodyStates currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        models = new GameObject[totalStates];
        defaultState();
        previousState = bodyStates.full;
        currentState = bodyStates.full;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (previousState == currentState){return;}
        
        
        Debug.Log("Change in state: " + previousState + " -> " + currentState);
        Debug.Log("Change in state: " + models[(int)previousState] + " -> " + models[(int)currentState]);
        
        models[(int)currentState].SetActive(true);
        models[(int)previousState].SetActive(false);
        
        animator.SetInteger("BodyState", (int)currentState);

        previousState = currentState;

    }

    
    void defaultState()
    {
        for(int i=0; i < totalStates; i ++)
        {
            models[i] = GameObject.Find(modelNames[i]);
            models[i].SetActive(false);
        }
        models[(int)bodyStates.full].SetActive(true);
    }


}
