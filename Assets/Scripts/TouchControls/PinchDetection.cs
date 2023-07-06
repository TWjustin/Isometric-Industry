using System;
using System.Collections;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 4f;
    
    private TouchControls controls;
    private Coroutine zoomCoroutine;

    private void Awake()
    {
        controls = new TouchControls();
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Zoominout.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Zoominout.SecondaryTouchContact.canceled += _ => ZoomEnd();
        controls.Zoominout.PrimaryTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetectuon());
    }
    
    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetectuon()
    {
        float previosDistance = 0f, distance = 0f;
        while (true)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2f, 10f);
            
            distance = Vector2.Distance(controls.Zoominout.PrimaryFingerPosition.ReadValue<Vector2>(), 
                controls.Zoominout.SecondaryFingerPosition.ReadValue<Vector2>());
            // Detection
            // Zoom out
            if (distance > previosDistance)
            {
                Camera.main.orthographicSize -= cameraSpeed * Time.deltaTime;
            }
            // Zoom in
            else if (distance < previosDistance)
            {
                Camera.main.orthographicSize += cameraSpeed * Time.deltaTime;
            }
            
            // Keep track of previous distance for next loop
            previosDistance = distance;
            yield return null;
        }
    }
}
