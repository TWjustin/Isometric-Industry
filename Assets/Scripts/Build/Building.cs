using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingSO buildingSO;

    public bool Placed { get; private set; }
    public int price;
    public int peopleToAdd;
    public BoundsInt area;
    
    #region Build Methods

    private void Start()
    {
        price = buildingSO.price;
        peopleToAdd = buildingSO.peopleToAdd;
        area = buildingSO.area;
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
        if (gameObject.name == "Road(Clone)")
        {
            GridBuildingSystem.current.TakeRoadArea(areaTemp);
        }
        else
        {
            GridBuildingSystem.current.TakeArea(areaTemp);
        }
    }

    #endregion
}
