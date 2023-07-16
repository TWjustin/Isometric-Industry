using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxStackedItems = 100;
    public InvenSlot[] invenSlots;
    public GameObject invenItemPrefab;
    
    int selectedSlotIndex = -1;

    private void Update()
    {
        // 用觸控取代

        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber)
            {
                int index = number - 1;
                if (index >= 0 && index < invenSlots.Length)
                {
                    ChangeSelectedSlot(index);
                }
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlotIndex >= 0)
        {
            invenSlots[selectedSlotIndex].Deselect();
        }

        invenSlots[newValue].Select();
        selectedSlotIndex = newValue;
    }
    
    public bool AddItem(Item item)
    {
        // find a slot with the same item
        for (int i = 0; i < invenSlots.Length; i++)
        {
            InvenSlot slot = invenSlots[i];
            InvenItem itemInSlot = slot.GetComponentInChildren<InvenItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        
        // find an empty slot
        for (int i = 0; i < invenSlots.Length; i++)
        {
            InvenSlot slot = invenSlots[i];
            InvenItem itemInSlot = slot.GetComponentInChildren<InvenItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        
        return false;
    }
    
    void SpawnNewItem(Item item, InvenSlot slot)
    {
        GameObject newItemGO = Instantiate(invenItemPrefab, slot.transform);
        InvenItem invenItem = newItemGO.GetComponent<InvenItem>();
        invenItem.InitializeItem(item);
    }

    // 暫時沒用
    public Item GetSelectedItem()
    {
        InvenSlot slot = invenSlots[selectedSlotIndex];
        InvenItem itemInSlot = slot.GetComponentInChildren<InvenItem>();
        if (itemInSlot != null)
        {
            return itemInSlot.item;
        }
        else
        {
            return null;
        }
    }
}
