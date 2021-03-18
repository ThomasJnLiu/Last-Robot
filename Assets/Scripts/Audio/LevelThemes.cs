using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThemes : MonoBehaviour
{   
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("scene loaded");
        switch(scene.name){
            case "EnvironmentScene1":
                AudioManager.instance.Play("Wind");
                break;
            case "EnvironmentScene2":
                        AudioManager.instance.Stop("Wind");

                AudioManager.instance.Play("Theme1");
                break;  
            case "EnvironmentScene3":
                Debug.Log(scene.name);
                break;    
            case "EnvironmentScene4":
                AudioManager.instance.Stop("Theme1");

                AudioManager.instance.Play("Theme2");
                break;                              
            default:
                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        Debug.Log(scene.name);
        Debug.Log(mode);
    }
}
