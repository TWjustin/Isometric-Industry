using UnityEngine;
using UnityEngine.Tilemaps;

public class TruckGenerator : MonoBehaviour
{
    private Tilemap roadTilemap;
    public GameObject truckPrefab;
    
    private void Start()
    {
        roadTilemap = GameObject.Find("RoadTilemap").GetComponent<Tilemap>();
        Debug.Log(roadTilemap);
    }

    public void GenerateOnTiles()
    {
        BoundsInt bounds = roadTilemap.cellBounds;
        TileBase[] allTiles = roadTilemap.GetTilesBlock(bounds);

        Vector3Int originCellPos = Vector3Int.zero;
        float closestDistance = Mathf.Infinity;
        Vector3 spawnPos = Vector3.zero;

        for (int x = bounds.min.x; x < bounds.max.x; x++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = allTiles[(x - bounds.x) + (y - bounds.y) * bounds.size.x];

                if (tile != null)
                {
                    Vector3Int cellPos = roadTilemap.LocalToCell(roadTilemap.CellToLocalInterpolated(tilePos));
                    float distance = Vector3.Distance(originCellPos, cellPos);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        spawnPos = roadTilemap.CellToWorld(tilePos);
                    }
                }
            }
        }

        if (closestDistance != Mathf.Infinity)
        {
            Instantiate(truckPrefab, spawnPos, Quaternion.identity);
        }
    }
}
