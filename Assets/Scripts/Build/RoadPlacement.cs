using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class RoadPlacement : MonoBehaviour
{
    private bool placementMode = false;
    
    public Tilemap roadTilemap;
    public TileBase road;
    
    public void PlaceRoad()
    {
        Buy.Instance.CloseShop();
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            // 在這裡使用 touchPosition 進行相應的處理
            if (touch.phase == TouchPhase.Began)
            {
                placementMode = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (placementMode)
                {
                    Vector3Int startPosition = roadTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(touchPosition));
                    Vector3Int endPosition = roadTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(touchPosition));
                    startPosition.z = 0;
                    endPosition.z = 0;
                    
                    // 檢查是否為直線或橫線
                    if (Mathf.Abs(endPosition.x - startPosition.x) > Mathf.Abs(endPosition.y - startPosition.y))
                    {
                        endPosition.y = startPosition.y; // 將終點的y座標設為起點的y座標，形成橫線
                    }
                    else
                    {
                        endPosition.x = startPosition.x; // 將終點的x座標設為起點的x座標，形成直線
                    }

                    Vector3Int direction = endPosition - startPosition;
                    int distance = Mathf.Max(Mathf.Abs(direction.x), Mathf.Abs(direction.y));

                    direction.x = Mathf.Clamp(direction.x, -1, 1);
                    direction.y = Mathf.Clamp(direction.y, -1, 1);

                    Vector3Int currentPosition = startPosition;
                    for (int i = 0; i <= distance; i++)
                    {
                        roadTilemap.SetTile(currentPosition, road);
                        currentPosition += direction;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                placementMode = false;
            }
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