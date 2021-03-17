using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerParticles : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+37.5f, player.transform.position.z);
    }
}
