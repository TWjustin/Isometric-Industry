using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    private GridBuildingSystem gridBuildingSystem;
    private Building building;
    
    private Text playerMoneyText;
    private Text populationText;

    public float offset = 0.03f;
    
    private void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
        building = transform.parent.gameObject.GetComponent<Building>();
        playerMoneyText = GameObject.Find("PlayerMoneyText").GetComponent<Text>();
        populationText = GameObject.Find("PopNum").GetComponent<Text>();
    }

    public void Settle()
    {
        GridLayout gridLayout = gridBuildingSystem.gridLayout;
        Building temp = gridBuildingSystem.temp;
        
        if (temp.CanBePlaced())
        {
            Vector3 cellPos = gridLayout.LocalToCell(temp.transform.position);
            temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos 
                                                                              + new Vector3(offset, offset, 0));
            temp.Place();

            Buy();
            AddPeople();
            Destroy(gameObject);
        }
    }

    public void Rotate()
    {
        
    }

    public void Cancel()
    {
        gridBuildingSystem.ClearArea();
        Destroy(transform.parent.gameObject);
    }
    
    public void Buy()
    {
        int price = building.price;
        int playerMoney = int.Parse(playerMoneyText.text);
        if (playerMoney >= price)
        {
            playerMoney -= price;
            playerMoneyText.text = playerMoney.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    
    public void AddPeople()
    {
        int peopleToAdd = building.peopleToAdd;
        int totalPeople = int.Parse(populationText.text);
        totalPeople += peopleToAdd;
        populationText.text = totalPeople.ToString();
    }
}
