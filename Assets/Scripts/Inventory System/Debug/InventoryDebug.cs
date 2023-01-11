using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryDebug : MonoBehaviour
{   
    public UIDocument uiDoc;
    public InventoryObject inventory;
    public VisualTreeAsset sourceAsset1;
    public VisualTreeAsset sourceAsset2;
    public InventoryUIController inventoryUI;
    public ToolbarInventoryUIController toolbarInventoryUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            SetVTA(sourceAsset1);
            toolbarInventoryUI.Load();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            SetVTA(sourceAsset2);
            inventoryUI.Load();
            
        }

        // if(Input.GetKeyDown(KeyCode.LeftArrow)){
        //     CastSpell(damage * 10);
        // }

        // if(Input.GetKeyDown(KeyCode.RightArrow)){
        //     GainExp(damage * 25);
        // }
    }

    private void AddItemToInventory(ItemObject _item){
        inventory.AddItem(_item,1);

    }

    private void SetVTA(VisualTreeAsset asset){
        uiDoc.visualTreeAsset = asset;
    }

}
