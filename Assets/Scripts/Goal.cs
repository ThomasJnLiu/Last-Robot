    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{    
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(){
        if(scene.name == "walking_tutorial1"){
            SceneManager.LoadScene("walking_tutorial3");
        }else if(scene.name == "walking_tutorial3"){
            SceneManager.LoadScene("walking_tutorial2");
        }else if(scene.name == "EnvironmentScene1"){
            SceneManager.LoadScene("EnvironmentScene2");
        }
        else if(scene.name == "EnvironmentScene2"){
            SceneManager.LoadScene("EnvironmentScene3");
        }

    }
}
