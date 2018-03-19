using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour {

    public AudioClip AudioSource;
    AudioSource audio;
    public float volume;

	//Get audio source
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
    //Play end game sound when player hits game over trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            audio.PlayOneShot(AudioSource);
        }
    }

}
