using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RotationBlur : MonoBehaviour
{

    public CSTriggers triggers;

    void Start()
    {
        if (triggers != null)
        {
            triggers.OnRotationDetected += OnRotationDetected;
            triggers.OnRotationStopped += OnRotationStopped;
        }
    }

    public void OnRotationDetected(float angle)
    {
        //Debug.Log("Rotation detected: " + angle + " degrees");
        GetComponent<PostProcessVolume>().enabled = true;
    }

    public void OnRotationStopped()
    {
        //Debug.Log("Rotation stopped");
        GetComponent<PostProcessVolume>().enabled = false;
    }

    void OnDestroy()
    {
        if (triggers != null)
        {
            triggers.OnRotationDetected -= OnRotationDetected;
            triggers.OnRotationStopped -= OnRotationStopped;
        }
    }

    // Update is called once per frame

}
