using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonDoor : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter (Collision collision)
    {
        door.SetActive(false);
        gameObject.transform.GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
    }
    private void OnCollisionStay (Collision collision)
    { 
        door.SetActive(false);
    }

    private void OnCollisionExit (Collision collision){
        door.SetActive(true);   
        gameObject.transform.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
    }
}
