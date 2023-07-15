using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // 自己加的
    public BuildingSO buildingSO;
    public bool isMoving;

    // Placement
    public bool Placed { get; private set; }
    [HideInInspector]
    public BoundsInt area;
    
    private void Start()
    {
        area = buildingSO.area; // GridBuildingSystem會用到
    }
    
    #region Build Methods

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = buildingSO.area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.current.CanTakeArea(areaTemp))
        {
            return true;
        }

        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = buildingSO.area;
        areaTemp.position = positionInt;
        Placed = true;
        isMoving = false;
        
        GridBuildingSystem.current.TakeArea(areaTemp);
    }

    #endregion
}
