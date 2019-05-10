using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour {

    public AudioClip AudioSource;
    AudioSource gameAudio;
    public float volume;

	//Get audio source
	void Start () {
        gameAudio = GetComponent<AudioSource>();
	}
	
    //Play end game sound when player hits game over trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameAudio.PlayOneShot(AudioSource);
            iOSHapticController.instance.TriggerImpactMedium();
        }
    }

}
