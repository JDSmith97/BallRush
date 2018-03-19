using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoverPowerup : MonoBehaviour {

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
        //Freeze Y Axis
        ball.constraints = RigidbodyConstraints.FreezePositionY;
    }
    void Update()
    {
        
        if (PlayerController.gameOver == true)
        {
            ball.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), step);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
           ball.constraints = RigidbodyConstraints.None;
        }
    }
}
