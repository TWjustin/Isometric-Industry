using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/Crop", order = 2)]
public class FarmingSO : ScriptableObject
{
    public string cropName;
    public int price;
    public Sprite cropIcon;
    
    public int timeToGrow;
    public int harvestAmount;
    
    public Sprite[] growingSprite;
}
