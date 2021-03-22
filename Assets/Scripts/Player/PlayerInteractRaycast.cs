using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractRaycast : MonoBehaviour
{
    public PlayerController player;
    public LayerMask interactableLayer;

    public ControlsContext controlsContext;
    public delegate void ContextAction(PlayerInteractable interactable);
    public static event ContextAction OnContextEnter;
    public static event ContextAction OnContextExit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
 
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;

        if (Physics.SphereCast(new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), 1f, forward, out hit, 10f, interactableLayer))
        {
            OnContextEnter(hit.transform.gameObject.GetComponent<PlayerInteractable>());
        }
        else
        {
            OnContextExit(null);
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
