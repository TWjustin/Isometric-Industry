using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem current;
    
    public GridLayout gridLayout;
    public Tilemap Maintilemap;
    public Tilemap TempTilemap;
    public Tilemap RoadTilemap;
    
    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    public Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;
    
    public TileBase whiteTile;
    public TileBase greenTile;
    public TileBase redTile;
    public TileBase roadTile;
    
    public GameObject buildingUI;

    #region Unity Methods

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.White, whiteTile);
        tileBases.Add(TileType.Green, greenTile);
        tileBases.Add(TileType.Red, redTile);
        tileBases.Add(TileType.Road, roadTile);
    }
    
    private void Update()
    {
        if (!temp)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            if (!temp.Placed)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(touchPos);

                if (prevPos != cellPos)
                {
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos 
                        + new Vector3(.5f, .5f, 0));
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
    }

    #endregion

    #region Tilemap Management

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        
        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }
    
    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    #endregion

    #region Building Placement

    public void InitializeWithBuilding(GameObject building)
    {
        GameObject spawned = Instantiate(building, Vector3.zero, Quaternion.identity);
        temp = spawned.GetComponent<Building>();
        
        // 自己加的
        temp.isMoving = true;
        // UI
        Vector3 uiPos = spawned.transform.position + new Vector3(0f, 3f, 0f);
        GameObject uiFollow = Instantiate(buildingUI, uiPos, Quaternion.identity);
        uiFollow.transform.SetParent(spawned.transform);
        
        FollowBuilding();
    }

    public void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        TempTilemap.SetTilesBlock(prevArea, toClear);
    }

    private void FollowBuilding()
    {
        ClearArea();
        
        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;
        
        TileBase[] baseArray = GetTilesBlock(buildingArea, Maintilemap);
        
        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < size; i++)
        {
            if (baseArray[i] == tileBases[TileType.White])
            {
                tileArray[i] = tileBases[TileType.Red];
            }
            else
            {
                FillTiles(tileArray, TileType.Green);
                break;
            }
        }
        
        TempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, Maintilemap);
        TileBase[] roadBasesArray = GetTilesBlock(area, RoadTilemap);
        
        foreach (var b in baseArray)
        {
            if(b == tileBases[TileType.White])
            {
                Debug.Log("Can't take area");
                return false;
            }
            
            // 自己加的
            if (!IfNeighborRoad())
            {
                Debug.Log("No neighbor road");
                return false;
            }
        }
        
        foreach (var b in roadBasesArray)
        {
            if (b == tileBases[TileType.Road])
            {
                Debug.Log("There is a road");
                return false;
            }
        }

        return true;
    }
    
    // 自己加的
    public bool IfNeighborRoad()
    {
        Vector3Int cellPos = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt areaTemp = new BoundsInt(cellPos + new Vector3Int(-1, -1, 0), temp.area.size + new Vector3Int(2, 2, 0));

        foreach (Vector3Int pos in areaTemp.allPositionsWithin)
        {
            if (RoadTilemap.GetTile(pos) == tileBases[TileType.Road])
            {
                return true;
            }
        }
        return false;
    }
    
    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, TileType.Empty, TempTilemap);
        SetTilesBlock(area, TileType.White, Maintilemap);
    }

    #endregion
}

public enum TileType
{
    Empty,
    White,
    Green,
    Red,
    Road
}