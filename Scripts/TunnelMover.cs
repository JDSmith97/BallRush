using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMover : MonoBehaviour {

    private float step;
    private Rigidbody tunnel;
    private float startTime;
    private int seconds;

    private void Start()
    {
        //Create step value
        step = Random.Range(10, 13) * Time.deltaTime;
        //Define rigidbody
        tunnel = GetComponent<Rigidbody>();
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
            tunnel.constraints = RigidbodyConstraints.FreezePosition;
        }
        //Start moving tunnel with moving platform after 1 second
        else if (seconds > 1)
        {
            tunnel.position = Vector3.MoveTowards(transform.position, new Vector3(31f, 0f, 0f), 0.008f); //0.008
        }
    }
}
