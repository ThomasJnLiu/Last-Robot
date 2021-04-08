using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{    
    private Scene scene;
    public SceneManagement SceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(){
        if(scene.name == "walking_tutorial1"){
            // SceneManagement.FadeToLevel(2);
            // SceneManager.LoadScene("walking_tutorial3");
        }else if(scene.name == "walking_tutorial3"){
            // SceneManagement.FadeToLevel(3);
            // SceneManager.LoadScene("walking_tutorial2");
        }else if(scene.name == "EnvironmentScene1"){
            // SceneManager.LoadScene("EnvironmentScene2");
            SceneManagement.FadeToLevel(2);
        }
        else if(scene.name == "EnvironmentScene2"){
            SceneManagement.FadeToLevel(3);
            // SceneManager.LoadScene("EnvironmentScene3");
        }
        else if(scene.name == "EnvironmentScene3"){
            SceneManagement.FadeToLevel(4);
            // SceneManager.LoadScene("EnvironmentScene4");
        }
        else if(scene.name == "EnvironmentScene4"){
            SceneManagement.FadeToLevel(5);
        }
    }
}
