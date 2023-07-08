using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinchDetection : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 4f;
    [SerializeField]
    private float minZoom = 2f;
    [SerializeField]
    private float maxZoom = 10f;

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
        // controls.Zoominout.PrimaryTouchContact.canceled += _ => ZoomEnd();
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
        while (!IsPointerOverUI())
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
            
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
    
    // 檢查觸摸點是否在 UI 元素上
    private bool IsPointerOverUI()
    {
        if (EventSystem.current != null)
        {
            // 檢查觸摸點是否在 UI 元素上
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        return false;
    }
}
