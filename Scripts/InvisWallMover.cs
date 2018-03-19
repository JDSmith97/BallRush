using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisWallMover : MonoBehaviour {

    private Rigidbody wall;
    private float startTime;
    private int seconds;

    private void Start()
    {
        //Get wall rigidbody so it can be moved
        wall = GetComponent<Rigidbody>();
        //Get start time of game
        startTime = Time.time;
    }
    void Update()
    {
        //Get time
        float t = Time.time - startTime;
        //Round time into integer for comparison
        seconds = Mathf.RoundToInt(t);

        //Freeze InvisWall if game is over
        if (PlayerController.gameOver == true)
        {
            wall.constraints = RigidbodyConstraints.FreezePosition;
        }
        //Start moving InvisWall after 1 second
        else if (seconds > 1)
        {
            wall.position = Vector3.MoveTowards(transform.position, new Vector3(5f, 0f, 0f), 0.008f);
        }
    }
}
