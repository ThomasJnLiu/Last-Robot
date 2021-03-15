using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : NonPlayerInteractable
{
    private bool open, active;
    private static float speed = 15;
    private GameObject platform;
    private static float openLimit;
    private static float closedLimit = -73;

    // Start is called before the first frame update
    void Start()
    {
        open = true;
        active = false;
        platform = GameObject.Find("RetractableBridge");
        openLimit = platform.transform.position.z;
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
    
    private void closePlatform()
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

    private void openPlatform()
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

    private void Use(GameObject actor, bool isOpen) {
        if (!active && trigger == actor && open == isOpen)
            active = true;
    }

    public override void Use(GameObject actor)
    {
        Use(actor, false);
    }

    public override void Reset(GameObject actor)
    {
        Use(actor, true);
    }

}
