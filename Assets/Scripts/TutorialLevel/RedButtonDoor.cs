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
        door.SetActive(true);
    }
    private void OnCollisionStay (Collision collision)
    {
        door.SetActive(false);
    }

    private void OnCollisionExit (Collision collision){
        door.SetActive(true);
    }
}
