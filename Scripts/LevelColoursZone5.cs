using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColoursZone5 : MonoBehaviour {

    public int[] colours = { 1, 2, 3, 4, 5 };
    public int arrayPos;

    public Material[] material;
    public MeshRenderer meshRenderer;

    public Renderer zone1;

    float fadeTime = 2f;
    float fadeStart = 0;

    Color32 red = new Color32(255, 23, 23, 255);
    Color32 platformColour = new Color32(72, 57, 94, 255);

    public GameObject zone;

    private void Awake()
    {
        arrayPos = PlayerPrefs.GetInt("LevelColour");

        colours[arrayPos] = PlayerPrefs.GetInt("LevelColour");

        zone1 = gameObject.GetComponent<Renderer>();

        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        if (colours[arrayPos] == 0)
        {
            meshRenderer.sharedMaterial = material[0];
            platformColour = new Color32(72, 57, 94, 255);
        }
        if (colours[arrayPos] == 1)
        {
            meshRenderer.sharedMaterial = material[1];
            platformColour = new Color32(124, 49, 49, 255);
        }
        if (colours[arrayPos] == 2)
        {
            meshRenderer.sharedMaterial = material[2];
            platformColour = new Color32(43, 112, 65, 255);
        }
        if (colours[arrayPos] == 3)
        {
            meshRenderer.sharedMaterial = material[3];
            platformColour = new Color32(92, 92, 92, 255);
        }
        if (colours[arrayPos] == 4)
        {
            meshRenderer.sharedMaterial = material[4];
            platformColour = new Color32(53, 93, 107, 255);
        }
    }

    // Update is called once per frame
    void Update () {
        
        if(PlayerController.gameOver == false | PlayerController.levelComplete == false)
        {
            if (PlayerController.zoneWarning5 == true)
            {
                StartCoroutine(WaitForZone());

                zone.SetActive(true);
            }
        }
        
    }

    IEnumerator WaitForZone()
    {
        //change colour of zone
        if (fadeStart < fadeTime)
        {
            fadeStart += Time.deltaTime * fadeTime;

            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(platformColour, red, fadeStart);

        }

        yield return new WaitForSeconds(2f);
        //release zone
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }

}
