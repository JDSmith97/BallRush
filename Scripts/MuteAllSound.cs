using UnityEngine;
using System.Collections;

public class MuteAllSound : MonoBehaviour
{

    //Turn sound off if player hits end game trigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioListener.volume = 0;
        }
    }

    //Mute game sound by turning off audio listener
    public void Mute()
    {
        AudioListener.volume = 0;
    }
}