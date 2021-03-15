using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerInteractable : Interactable
{

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fix(GameObject actor)
    {
        throw new System.NotImplementedException();
    }
}
