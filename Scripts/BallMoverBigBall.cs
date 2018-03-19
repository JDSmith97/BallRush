using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoverBigBall : MonoBehaviour {

    float step;
    public float x;
    public float y;
    public float z;
    private Rigidbody ball;

    private void Start()
    {
        //Create step value
        step = Random.Range(3, 5) * Time.deltaTime;
        //Define rigidbody
        ball = GetComponent<Rigidbody>();
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
  
}
