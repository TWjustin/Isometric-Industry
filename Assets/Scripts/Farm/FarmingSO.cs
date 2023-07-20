using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/Crop", order = 2)]
public class FarmingSO : ScriptableObject
{
    public string cropName;
    public int price;
    public Sprite cropIcon;
    public int harvestAmount;
    
    public Sprite[] growingSprite;
    
    public Item cropItem;
    
    [Header("Production Time")]
    public int Hours;
    public int Minutes;
    public int Seconds;
}
