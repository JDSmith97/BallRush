﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAreaMover : MonoBehaviour {

    private Rigidbody dangerarea;
    private float startTime;
    private int seconds;

    private void Start()
    {
        //Define rigidbody
        dangerarea = GetComponent<Rigidbody>();
        //Get start time
        startTime = Time.time;
    }
    void Update()
    {
        //Get time
        float t = Time.time - startTime;

        //Round time into integer for comparison
        seconds = Mathf.RoundToInt(t);

        //Freeze tunnel position if game is over
        if (PlayerController.gameOver == true || PlayerController.levelComplete == true)
        {
            dangerarea.constraints = RigidbodyConstraints.FreezePosition;
        }
        //Start moving danger area with moving platform after 1 second
        else if (seconds > 1)
        {
            dangerarea.position = Vector3.MoveTowards(transform.position, new Vector3(-6.8f, 0f, -0f), 0.008f); //0.008
        }
    }
}
