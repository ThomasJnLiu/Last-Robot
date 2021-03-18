using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private GameObject arm, gear;
    private GearMove gear_animation;
    private LeverMove lever_animation;
    private Renderer button;
    public bool temp_use, temp_lever;

    
    // Start is called before the first frame update
    void Start()
    {
        arm = GameObject.Find("Lever_Arms_Parent");
        button = GameObject.Find("Lever_Button").GetComponent<Renderer>();
        gear = GameObject.Find("Lever_Gear");
        
        gear_animation = GameObject.Find("Lever_Gear/polySurface61").GetComponent<GearMove>();
        lever_animation = arm.GetComponent<LeverMove>();

        arm.SetActive(false);
        button.material.SetColor("_Color", new Color(0.5f, 0.0f, 0.0f, 1.0f));
        
        
        

        temp_use = false;
        temp_lever = false;
    }

    
    // Update is called once per frame
    void Update()
    {
       

    }

    public void fixLever (bool use)
    {
        if (use)
        {
            arm.SetActive(true);
            gear_animation.active = true;
        }
        else
        {
            arm.SetActive(false);
            gear_animation.active = false;
        }
    }
    
    public void useLever (bool use)
    {
        if (use)
        {
            AudioManager.instance.Play("PlatformSFX");

            button.material.SetColor("_Color", new Color(201/255, 231/255, 187/255, 255/255));
            lever_animation.status = true;
        }
        else
        {
            AudioManager.instance.Play("PlatformSFX");

            button.material.SetColor("_Color", new Color(158/255, 95/255, 96/255, 255/255));
            lever_animation.status = false;
        }
    }
}
