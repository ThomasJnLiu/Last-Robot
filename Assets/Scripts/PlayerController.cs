using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 playerVelocity;

    public Transform cam;

    public GameObject box;
    public GameObject brokenArm;

    public bool canGrab;
    public bool isGrabbing;
    public bool canFix;

    public bool grabbingItem = false;
    public bool groundedPlayer;
    public bool canTurn;
    public float playerSpeed = 20.0f;
    public float jumpSpeed = 10.0f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();

        canGrab = false;
        canFix = false;
    }

    // Update is called once per frame
    void Update()
    {
        // int armsLeft;
        // canGrab = false;
        // if (!isGrabbing && partsLeft.TryGetValue(Parts.Arm, out armsLeft)) {
        //     if (armsLeft == 2) {
        //         canGrab = true;
        //     }
        // }

        // if (interactable && interactable.state == Interactable.State.Broken) {
        //     int piecesLeft = 0;
        //     canFix = false;
        //     if (partsLeft.TryGetValue(Parts.Arm, out piecesLeft)) {
        //         if (piecesLeft > 0) {
        //             canFix = true;
        //         }
        //     } 
        // }
    }

    // Check if object is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == gameObject)
        {
            return;
        }

        groundedPlayer = true;
    }

    // Check if the object is in the air
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == gameObject)
        {
            return;
        }

        groundedPlayer = false;
    }

    public void GetGrabTaget(GameObject otherGameobject){
        box = otherGameobject;
    }

    public void GetFixTarget(GameObject otherGameobject) {
        brokenArm = otherGameobject;
    }
}
