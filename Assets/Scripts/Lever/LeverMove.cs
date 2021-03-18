using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : MonoBehaviour
{

    public bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (status && this.transform.eulerAngles.x < 50)
        {
            this.transform.Rotate(new Vector3 (30, 0, 0) * Time.deltaTime);
        }
        else if (!status && this.transform.eulerAngles.x > 10)
        {
            this.transform.Rotate(new Vector3 (-30, 0, 0) * Time.deltaTime);
        }
        
    }
}
