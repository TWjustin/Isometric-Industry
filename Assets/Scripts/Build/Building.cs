using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingSO buildingSO;

    public bool Placed { get; private set; }
    [HideInInspector]
    public BoundsInt area;
    
    #region Build Methods

    private void Start()
    {
        area = buildingSO.area; // GridBuildingSystem會用到
    }

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
        
        GridBuildingSystem.current.TakeArea(areaTemp);
    }

    #endregion
}
