/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    static SaveObject saveData;

    private void Start()
    {
        //GameObject.Find("Inventory");

        //upon being initialized, item is added to the scavenger hunt item list
        InventorySystem.instance.Add(referenceItem);
        Debug.Log("Item Add() Attempt");
        
    }

    /// <summary>
    /// When an item is selected, it's data is removed from the InventorySystem and corresponding gameObject is destroyed
    /// </summary>
    public void OnHandlePickupItem()
    {
        Debug.Log(referenceItem.displayName);
        InventorySystem.instance.Remove(referenceItem);
        saveData = SaveManager.Load();
        saveData.TimeElapsed = TimeManager.instance.GetElapsedTime();
        SaveManager.Save(saveData);
        Destroy(gameObject);
    }
}
