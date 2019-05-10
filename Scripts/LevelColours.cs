using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColours : MonoBehaviour {

    public int[] colours = { 1, 2, 3, 4, 5 };
    public int arrayPos;

    public Material[] material;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        arrayPos = PlayerPrefs.GetInt("LevelColour");
    }

    // Update is called once per frame
    void Update () {
        colours[arrayPos] = PlayerPrefs.GetInt("LevelColour");

        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        if (colours[arrayPos] == 0)
        {
            meshRenderer.sharedMaterial = material[0];
        }
        if (colours[arrayPos] == 1)
        {
            meshRenderer.sharedMaterial = material[1];
        }
        if (colours[arrayPos] == 2)
        {
            meshRenderer.sharedMaterial = material[2];
        }
        if (colours[arrayPos] == 3)
        {
            meshRenderer.sharedMaterial = material[3];
        }
        if (colours[arrayPos] == 4)
        {
            meshRenderer.sharedMaterial = material[4];
        }
    }
}
