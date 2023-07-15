using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TooltipTrigger : MonoBehaviour
{
    public GameObject tooltip;
    public float offset = 1f;
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject touchedObject = hit.collider.gameObject;
                    if (touchedObject.CompareTag("Building") && touchedObject.GetComponent<Building>().isMoving == false)
                    {
                        Vector3 spawnPosition = touchedObject.transform.position + new Vector3(0, offset, 0);
                        GameObject uiFollow = Instantiate(tooltip, spawnPosition, Quaternion.identity);
                        uiFollow.transform.SetParent(touchedObject.transform);
                    }
                }
            }
        }
    }
}
