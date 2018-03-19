using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour {

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        //Destroy 3d balls when they hit destroy trigger below platform
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
            
    }
}
