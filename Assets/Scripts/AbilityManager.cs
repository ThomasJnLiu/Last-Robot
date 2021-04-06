using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityManager : MonoBehaviour
{
    private PlayerController player;
    private PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();
        playerInteraction = playerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            if (playerInteraction.interactable) {
                playerInteraction.interactable.Interact(player.gameObject);
            }
        }

        if (Input.GetKeyDown("f")) {
            if (playerInteraction.interactable) {
                playerInteraction.interactable.FixUnfix(player.gameObject);
            }
        }
    }
}
