using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIContainer : MonoBehaviour
{
    //Singleton
    public static InventoryUIContainer Instance { get; private set; }

    public InventoryObject inventory;
    public List<InventoryItemIcon> InventoryItems = new List<InventoryItemIcon>();
    public int slotCount;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

        //Initializes the UI Inventory List using the data from the InventoryObject Scriptable Object
        for (int i = 0; i < slotCount; i++)
        {
            InventoryItemIcon item = new InventoryItemIcon();
            
            if(i < inventory.Container.Count){
                item.HoldItem(inventory.Container[i].item, inventory.Container[i].amount);
            }

            InventoryItems.Add(item);
        }
    }


}
