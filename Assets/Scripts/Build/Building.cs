using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingState
{
    Idle,
    InProgress,
    Finished
}

public class Building : MonoBehaviour
{
    // 自己加的
    public BuildingSO buildingSO;
    public ExeBtnSelector exeBtnSelector;
    public bool isMoving;   // TooltipTrigger會用到
    public BuildingState currentState;

    // 原本的
    public bool Placed { get; private set; }
    [HideInInspector]
    public BoundsInt area;
    
    private void Start()
    {
        area = buildingSO.area; // GridBuildingSystem會用到
        currentState = BuildingState.Idle; // 初始状态为Idle
        exeBtnSelector.SelectPlant();
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

    #region FSM

    private void Update()
    {
        // 根據建築物的狀態執行對應行為
        switch (currentState)
        {
            case BuildingState.Idle:
                // 在Idle状态下，你可以执行相应的行为
                break;

            case BuildingState.InProgress:
                // 在InProgress状态下，你可以执行相应的行為
                break;

            case BuildingState.Finished:
                // 在Finished状态下，你可以执行相应的行為
                break;
        }
    }
    
    // 在此处实现建築物狀態切换的逻辑
    public void ChangeState(BuildingState newState)
    {
        currentState = newState;
        // 在状态切换时，你可以执行相应的行为
        switch (currentState)
        {
            case BuildingState.Idle:
                // 进入Idle状态时的行为
                exeBtnSelector.SelectPlant();
                break;

            case BuildingState.InProgress:
                // 进入InProgress状态时的行为
                exeBtnSelector.SelectSkip();
                break;

            case BuildingState.Finished:
                // 进入Finished状态时的行为
                exeBtnSelector.SelectHarvest();
                break;
        }
    }

    #endregion
}