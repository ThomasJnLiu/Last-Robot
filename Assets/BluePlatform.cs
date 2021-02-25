using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatform : MonoBehaviour
{
    public bool open, active;
    private static float speed = 15;
    private GameObject platform;
    private static float openLimit = -43;
    private static float closedLimit = -73;

    // Start is called before the first frame update
    void Start()
    {
        open = true;
        active = false;
        platform = GameObject.Find("Blue Platform");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (open)
            {
                closePlatform();
            }
            else
            {
                openPlatform();
            }
        }
    }
    
    public void closePlatform()
    {
        if (platform.transform.position.z > closedLimit)
        {
            platform.transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);    
        }
        else
        {
            // Platform is closed
            open = false;
            active = false;
        }
    }

    public void openPlatform()
    {
        if (platform.transform.position.z < openLimit)
        {
            platform.transform.Translate(Vector3.forward * 1 * speed * Time.deltaTime);    
        }
        else
        {
            // Platform is open
            open = true;
            active = false;
        }
    }
    
}
