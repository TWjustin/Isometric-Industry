using UnityEngine;
using UnityEngine.InputSystem;

public class Swipe : MonoBehaviour
{
    #region Events

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    #endregion
    
    private TouchControls controls;
    private Camera mainCamera;

    private void Awake()
    {
        controls = new TouchControls();
        mainCamera = Camera.main;
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Swipe.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        controls.Swipe.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }
    
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Util.ScreenToWorld(mainCamera, controls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Util.ScreenToWorld(mainCamera, controls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    
    public Vector2 PrimaryPosition()
    {
        return Util.ScreenToWorld(mainCamera, controls.Swipe.PrimaryPosition.ReadValue<Vector2>());
    }
}
