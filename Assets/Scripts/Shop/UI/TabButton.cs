using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour
{
    public TabGroup tabGroup;
    
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    public void Pressed()
    {
        tabGroup.OnTabSelected(this);
    }

    void Start()
    {
        tabGroup.Subscribe(this);
    }

    public void Select()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }
    
    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }
    }
}
