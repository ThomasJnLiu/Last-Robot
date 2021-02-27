using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    public bool lifted, active;
    private static float speed = 15;
    private GameObject platform;
    private static float liftLimit = 15;
    private static float dropLimit = 3;
    private static int delay;
    private static float platformTimer = 0.0f;
    private static float platformDelay = 3.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lifted = false;
        active = false;
        platform = GameObject.Find("LiftPlatform");
        dropLimit = platform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (lifted)
            {
                platformTimer += Time.deltaTime;
                if (platformTimer > platformDelay)
                {
                    dropPlatform();                    
                }
            }
            else
            {
                liftPlatform();
            }
        }
    }

    
    public void dropPlatform()
    {
        if (platform.transform.position.y > dropLimit)
        {
            platform.transform.Translate(Vector3.up * -1 * speed * Time.deltaTime);    
        }
        else
        {
            // Platform is dropped
            lifted = false;
            active = false;
            platformTimer = 0.0f;
        }
    }

    public void liftPlatform()
    {
        if (platform.transform.position.y < liftLimit)
        {
            platform.transform.Translate(Vector3.up * 1 * speed * Time.deltaTime);    
        }
        else
        {
            // Platform is lifted
            lifted = true;
        }
    }
}
