using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class RoadPlacement : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase roadTile;
    public Button placeRoadButton;
    public GameObject shop;

    private bool isPlacingRoad = false;
    private Vector3Int startCellPosition;
    private Vector3Int endCellPosition;

    private void Start()
    {
        placeRoadButton.onClick.AddListener(StartPlacingRoad);
    }

    private void Update()
    {
        if (isPlacingRoad && Input.GetMouseButton(0))
        {
            endCellPosition = GetMouseCellPosition();

            // 拖曳時的鋪路邏輯
            PlaceRoadsBetweenCells(startCellPosition, endCellPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPlacingRoad = false;
        }
    }

    private void StartPlacingRoad()
    {
        shop.SetActive(false);
        isPlacingRoad = true;
        startCellPosition = GetMouseCellPosition();
    }

    private void PlaceRoadsBetweenCells(Vector3Int start, Vector3Int end)
    {
        Vector3Int minPosition = Vector3Int.Min(start, end);
        Vector3Int maxPosition = Vector3Int.Max(start, end);

        for (int x = minPosition.x; x <= maxPosition.x; x++)
        {
            for (int y = minPosition.y; y <= maxPosition.y; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                tilemap.SetTile(position, roadTile);
            }
        }
    }

    private Vector3Int GetMouseCellPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
        return cellPosition;
    }
}