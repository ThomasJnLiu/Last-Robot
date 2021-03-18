using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : NonPlayerInteractable
{
    public bool open, active;
    private static float speed = 10;
    private GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        open = true;
        active = false;
        platform = GameObject.Find("RetractableBridge");
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
                Debug.Log("Here2");
                openPlatform();
            }
        }
    }
    
    private void closePlatform()
    {
        if (platform.transform.localScale.z > 0f)
        {
            // platform.transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);
            platform.transform.localScale = new Vector3(1, 1, platform.transform.localScale.z - (0.1f * speed * Time.deltaTime));
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
        if (platform.transform.localScale.z < 1f)
        {
            // platform.transform.Translate(Vector3.forward * 1 * speed * Time.deltaTime);  
            Debug.Log("Hi");
            platform.transform.localScale = new Vector3(1, 1, platform.transform.localScale.z + (0.1f * speed * Time.deltaTime));
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

    public override bool Use(GameObject actor)
    {
        Use(actor, true);
        return true;
    }

    public override bool Reset(GameObject actor)
    {
        Use(actor, false);
        return true;
    }

}
