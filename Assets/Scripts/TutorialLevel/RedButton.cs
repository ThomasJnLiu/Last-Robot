using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public RedPlatform redPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        redPlatform = FindObjectOfType<RedPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("collision with red button");
        redPlatform.active = true;
    }
    
}
