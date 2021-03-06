﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour {

    float step;
    public float x;
    public float y;
    public float z;
    private Rigidbody ball;

    private void Start()
    {
        //Create step value
        step = Random.Range(10, 13) * Time.deltaTime;
        //Define rigidbody
        ball = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (PlayerController.gameOver == true || PlayerController.levelComplete == true)
        {
            ball.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), step);
        }
    }


}
