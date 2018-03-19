using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpRB")
            Destroy(other.gameObject);

        if (other.gameObject.tag == "PickUpResize")
            Destroy(other.gameObject);

        if (other.gameObject.tag == "PickUpSpawnCount")
            Destroy(other.gameObject);
    }
}
