using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDebug : MonoBehaviour
{   
    public InventoryObject inventory;
    public ItemObject debugItem1;
    public ItemObject debugItem2;
    public ItemObject debugItem3;
    public ItemObject debugItem4;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            AddItemToInventory(debugItem1);
        }

        // if(Input.GetKeyDown(KeyCode.DownArrow)){
        //     TakeDamage(damage);
        // }

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

}
