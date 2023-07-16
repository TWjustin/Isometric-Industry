using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }
    
    public void Deselect()
    {
        image.color = notSelectedColor;
    }
}
