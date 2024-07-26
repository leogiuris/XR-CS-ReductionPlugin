using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteListener : MonoBehaviour
{
    public CSTriggers triggers;

    void Start()
    {
        if (triggers != null)
        {
            triggers.OnAccelerationDetected += OnAccelerationDetected;
            triggers.OnRotationDetected += OnRotationDetected;
            triggers.OnRotationStopped += OnRotationStopped;
        }
    }

    public void OnAccelerationDetected(float acceleration)
    {
        Debug.Log("Acceleration detected: " + acceleration);
    }

    public void OnRotationDetected(float angle)
    {
        Debug.Log("Rotation detected: " + angle + " degrees");
    }

    public void OnRotationStopped()
    {
        Debug.Log("Rotation stopped");
    }

    void OnDestroy()
    {
        if (triggers != null)
        {
            triggers.OnAccelerationDetected -= OnAccelerationDetected;
            triggers.OnRotationDetected -= OnRotationDetected;
            triggers.OnRotationStopped -= OnRotationStopped;
        }
    }

}
