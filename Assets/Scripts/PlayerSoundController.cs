using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private static AudioClip jumpSound, grabSound;
    private static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Sounds/temp_jump");
        grabSound = Resources.Load<AudioClip>("Sounds/temp_grab");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayOneTime(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "grab":
                audioSrc.PlayOneShot(grabSound);
                break;
        }
        
    }

    public static void PlayWalk(bool walk)
    {
        if (walk && !audioSrc.isPlaying)
        {
            audioSrc.Play();
        }
        else if (!walk && audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
    }

}
