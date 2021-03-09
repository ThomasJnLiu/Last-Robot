using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractRaycast : MonoBehaviour
{
    public PlayerController player;
    public LayerMask interactableLayer;
    public bool hittingInteractable = false;

    public ControlsContext controlsContext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
 
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;

        if (Physics.SphereCast(new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), 2f, forward, out hit, 3f, interactableLayer))
        {
            player.GetGrabTaget(hit.transform.gameObject);
            controlsContext.AddContextFromTag(hit.transform.gameObject.tag);
            player.canGrab = true;
        }
        else
        {
            controlsContext.DisableControlsContext();
            player.canGrab = false;
        }
    }

    void OnDrawGizmos()
    {
        float maxDistance = 5f;
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;

        // Makes drawn gizmos rotate with player
        Gizmos.matrix = this.transform.localToWorldMatrix;

        // Representing the spherecast through gizmos was a big
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawRay(new Vector3(0, -2, 0), new Vector3(0, 0, 1f));
        Gizmos.DrawWireSphere(new Vector3(0, -2, 4), 3f);

    }
}
