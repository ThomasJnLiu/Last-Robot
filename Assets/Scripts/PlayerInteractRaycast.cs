using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractRaycast : MonoBehaviour
{
    public PlayerController player;
    public LayerMask interactableLayer;
    public bool hittingInteractable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            RaycastHit hit;

            // In Physics.Raycast, the length of the ray is given as a parameter
            // However in drawray, there is no length parameter, so the direction must be multiplied to determine the length of the ray
            // In order to make the ray made by raycast and drawray the same length, the direction vector is normalized
            // The direction vector in drawray is then multiplied by the length of the raycast
            // answers.unity.com/questions/665891/how-to-calculate-debugdrawray-length-to-match-rayc.html
            Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y-3f, transform.position.z), forward*5f, Color.red);
  
            if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y-3f, transform.position.z), forward, out hit, 5f, interactableLayer)){
                Debug.Log("hit");   
                Debug.Log(hit.transform.gameObject);
                player.GetGrabTaget(hit.transform.gameObject);
                player.canGrab = true;
            }else{
                player.canGrab = false;
            }
    }

}
