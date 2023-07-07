using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    private Vector2 touchStartPos;

    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && !IsPointerOverUI())
        {
            Vector2 deltaTouchPos = Input.GetTouch(0).deltaPosition;
            Vector3 movement = new Vector3(deltaTouchPos.x, deltaTouchPos.y, 0f);
            transform.Translate(-movement * movementSpeed * Time.deltaTime);
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