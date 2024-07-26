using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CSTriggers : MonoBehaviour
{
    // Variables for acceleration detection
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private Vector3 lastVelocity;
    private Vector3 currentVelocity;
    private Vector3 acceleration;
    public float accelerationThreshold = 1f; // Adjust the threshold as needed

    // Variables for rotation detection
    private Quaternion lastRotation;
    private Quaternion currentRotation;
    private Quaternion lastRotationOrigin;
    private Quaternion currentRotationOrigin;

    public float rotationThreshold = 0.5f; // Adjust the threshold as needed
    private bool wasRotating = false; // Track if the object was rotating in the previous frame
    private bool wasRotatingOrigin = false;

    // Events for acceleration and rotation detection
    public UnityAction<float> OnAccelerationDetected;

    public UnityAction<float> OnRotationDetected;
    public UnityAction OnRotationStopped;

    public UnityAction<float> OnRotationOriginDetected;
    public UnityAction OnRotationOriginStopped;

    private GameObject xrorigin;


    void Start()
    {
        xrorigin = FindObjectOfType<XROrigin>().gameObject;


        // Initialize position and velocity for acceleration detection
        lastPosition = transform.parent.position;
        currentPosition = transform.parent.position;
        lastVelocity = Vector3.zero;
        currentVelocity = Vector3.zero;
        acceleration = Vector3.zero;

        // Initialize rotation for rotation detection
        lastRotation = transform.parent.rotation;
        currentRotation = transform.parent.rotation;

        // Initialize rotation for rotation detection
        lastRotationOrigin = xrorigin.transform.rotation;
        currentRotationOrigin = xrorigin.transform.rotation;

    }

    void Update()
    {
        Debug.Log(xrorigin.transform.rotation);
        DetectAcceleration();
        DetectRotation();
        DetectRotationOrigin();
    }
    
    void DetectAcceleration()
    {
        float value;

        // Update current position and calculate current velocity for acceleration detection
        currentPosition = transform.parent.position;
        currentVelocity = (currentPosition - lastPosition) / Time.deltaTime;
        acceleration = (currentVelocity - lastVelocity) / Time.deltaTime;
        value = acceleration.magnitude;
        // Check if there is significant acceleration
        if (value > accelerationThreshold)
        {
            OnAccelerationDetected?.Invoke(value);
        }

        // Store the current position and velocity for the next frame
        lastPosition = currentPosition;
        lastVelocity = currentVelocity;
    }

    void DetectRotation()
    {
        // Update current rotation for rotation detection
        currentRotationOrigin = transform.parent.rotation;
        float angle = Quaternion.Angle(lastRotation, currentRotation);

        // Check if there is significant rotation
        if (angle > rotationThreshold)
        {
            OnRotationDetected?.Invoke(angle);
            wasRotating = true;
        }
        else
        {
            // Trigger rotation stopped event if the object was rotating previously and now has stopped
            if (wasRotating)
            {
                OnRotationStopped?.Invoke();
                wasRotating = false;
            }
        }
        // Store the current rotation for the next frame
        lastRotation = currentRotation;
    }

    void DetectRotationOrigin()
    {
        // Update current rotation for rotation detection
        currentRotationOrigin = xrorigin.transform.rotation;
        float angle = Quaternion.Angle(lastRotationOrigin, currentRotationOrigin);

        // Check if there is significant rotation
        if (angle > rotationThreshold)
        {
            Debug.Log("rotation origin");
            OnRotationOriginDetected?.Invoke(angle);
            wasRotatingOrigin = true;
        }
        else
        {
            // Trigger rotation stopped event if the object was rotating previously and now has stopped
            if (wasRotatingOrigin)
            {
                OnRotationOriginStopped?.Invoke();
                wasRotatingOrigin = false;
            }
        }
        // Store the current rotation for the next frame
        lastRotationOrigin = currentRotationOrigin;
    }


}
