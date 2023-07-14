using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadUI : MonoBehaviour
{
    public BuildingSO roadSO;
    
    private Tilemap roadTilemap;
    public TileBase road;
    
    private void Start()
    {
        roadTilemap = GridBuildingSystem.current.RoadTilemap;
    }
    
    public void Settle()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TempRoads"))
        {
            // Cost
            Buy.Instance._Buy(roadSO);

            // Tilemap
            Vector3Int tilePosition = roadTilemap.WorldToCell(go.transform.position);
            roadTilemap.SetTile(tilePosition, road);
        }
        Done();
    }
    
    public void Cancel()
    { 
        Done();
    }

    private void Done()
    {
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("TempRoads");
        foreach (GameObject obj in objectsToRemove)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
