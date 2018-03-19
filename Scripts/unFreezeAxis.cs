using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  unFreezeAxis : MonoBehaviour
{

    public Rigidbody player;

    void Start()
    {
        //Get player rigidboy object
        player = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Unfreeze Y Axis when player hits trigger to make the player actually "fall" off the edge of the platform
        if (other.tag == "Player")
        {
            player.constraints = RigidbodyConstraints.None;
        }
    }
}

