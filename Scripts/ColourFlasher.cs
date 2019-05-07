using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFlasher : MonoBehaviour
{

    public Material newColour;
    public MeshRenderer meshRenderer;
    public Material originalColour;
    public bool status;

    private void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        originalColour = meshRenderer.sharedMaterial;
    }

    public void Update()
    {
        if(status == true)
        {
            Flasher();
        }
        if(status == false)
        {
            meshRenderer.material = originalColour;
        }
    }
    IEnumerator Flasher()
    {
        for (int i = 0; i < 5; i++)
        {
            meshRenderer.material = newColour;
            yield return new WaitForSeconds(.1f);
            meshRenderer.material = originalColour;
            yield return new WaitForSeconds(.1f);
        }
    }
}
