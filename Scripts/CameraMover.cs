using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    private float step;
    private Rigidbody gameCamera;
    private float startTime;
    private int seconds;

    private void Start()
    {
        step = Random.Range(10, 13) * Time.deltaTime;
        gameCamera = GetComponent<Rigidbody>();
        startTime = Time.time;
    }
    void Update()
    {
        //Get time
        float t = Time.time - startTime;

        //Round time into integer for comparison
        seconds = Mathf.RoundToInt(t);

        //Freeze camera position if game is over
        if (PlayerController.gameOver == true)
        {
            gameCamera.constraints = RigidbodyConstraints.FreezePosition;
        }
        //Start moving camera with moving platform after 10 seconds
        else if (seconds > 10)
        {
            gameCamera.position = Vector3.MoveTowards(transform.position, new Vector3(-4f, 23.3f, -11.1f), 0.008f);
        }
    }
}
