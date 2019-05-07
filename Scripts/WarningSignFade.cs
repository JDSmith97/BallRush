using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignFade : MonoBehaviour {


    public float fadeSpeed = 1f;    // How fast alpha value decreases.
    public Material m_Material;    // Used to store material reference.

    // Use this for initialization
    void Start () {

        // Get reference to object's material.
        m_Material = GetComponent<Renderer>().material;

        StartCoroutine(warningFade());
    }
	
	// Update is called once per frame
	void Update () {
		

	}

    IEnumerator warningFade()
    {
        // Alpha start value.
        float alpha = 1.0f;

        // Loop until aplha is below zero (completely invisalbe)
        while (alpha > 0.0f)
        {
            // Reduce alpha by fadeSpeed amount.
            alpha -= fadeSpeed * Time.deltaTime;
        }

        yield return null;
    }
}
