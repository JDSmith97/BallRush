using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnMuteAudio : MonoBehaviour {
    
    //Activate audio listener
    public void UnMute() {
        AudioListener.volume = 1;
    }
}
