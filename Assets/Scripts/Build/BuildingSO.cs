using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building", order = 1)]
public class BuildingSO : ScriptableObject
{
    public int price;
    public int peopleToAdd;
    
    public Sprite buildingSprite;
    public string buildingName;
    
    public BoundsInt area;
    public GameObject buildingPrefab;
}