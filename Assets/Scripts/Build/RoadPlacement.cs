using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadPlacement : MonoBehaviour
{
    private bool placementMode = false;
    
    private Tilemap roadTilemap;
    public GameObject roadPrefab;
    public GameObject uiPrefab;
    public float offset = 1f;
    
    private void Start()
    {
        roadTilemap = GridBuildingSystem.current.RoadTilemap;
    }
    
    public void Update()
    {
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
                        Instantiate(roadPrefab, roadTilemap.CellToWorld(currentPosition), Quaternion.identity);
                        currentPosition += direction;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                placementMode = false;
                StartRoad.EndPlace();
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                spawnPosition.z = 0;
                spawnPosition.y += offset;
                Instantiate(uiPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}