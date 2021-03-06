﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAudio : MonoBehaviour
{

    public AudioClip AudioSource;
    AudioSource endAudio;
    public float volume;

    // Use this for initialization
    void Start()
    {
        //Get audio source
        endAudio = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //Play sound when player touches end game trigger
        if (other.gameObject.CompareTag("Player"))
        {
            endAudio.PlayOneShot(AudioSource);
        }

    }

}
