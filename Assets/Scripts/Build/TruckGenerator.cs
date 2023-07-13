using UnityEngine;
using UnityEngine.Tilemaps;

public class TruckGenerator : MonoBehaviour
{
    public BuildingSO buildingSO;
    private Tilemap roadTilemap;
    
    public float offset = 0.1f;
    
    private void Start()
    {
        roadTilemap = GameObject.Find("RoadTilemap").GetComponent<Tilemap>();
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
                        spawnPos = roadTilemap.CellToWorld(tilePos) + new Vector3(offset, offset, 0);
                    }
                }
            }
        }

        if (closestDistance != Mathf.Infinity)
        {
            Instantiate(buildingSO.buildingPrefab, spawnPos, Quaternion.identity);
        }
    }
}
