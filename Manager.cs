using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public bool VirtualNose = false;
    public bool RotationBlur = false;
    public bool Vignette = false;

    private GameObject nose;
    private GameObject postProcessing;
    private GameObject vignette;

    public Camera getCamera()
    {
        return GetComponentInParent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nose = transform.Find("VirtualNose").gameObject;
        nose.SetActive(VirtualNose);

        postProcessing = transform.Find("RotationBlur").gameObject;
        postProcessing.SetActive(RotationBlur);

        vignette = transform.Find("Vignette").gameObject;
        vignette.SetActive(Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
