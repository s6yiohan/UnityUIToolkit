using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting;

public class InventoryItemIcon : VisualElement
{
    public Image icon;
    public Label amountText;
    public ItemType type = 0;
    public ItemObject item;
    public int amount;

    public InventoryItemIcon (){
        
        icon = new Image();
        amountText = new Label();
        Add(icon);
        icon.Add(amountText);

        icon.AddToClassList("slotIcon");
        amountText.AddToClassList("slotAmount");
        AddToClassList("slotContainer");
    }
    
    //Sets the item icon from the ItemObject class and takes in the item ammount from the inventory scriptable object
    public void HoldItem(ItemObject p_item, int p_itemAmount){
        item = p_item;
        icon.image = item.itemIcon;
        type = p_item.type;
        amount = p_itemAmount;
        amountText.text = p_itemAmount.ToString();
    }

    public void DropItem(){
        item = null;
        icon.image = null;
        type = 0;
        amount = 0;
        amountText.text = "";
    }

    #region UXML
    [Preserve]
    public new class UxmlFactory : UxmlFactory<InventoryItemIcon, UxmlTraits> { }
    [Preserve]
    public new class UxmlTraits : VisualElement.UxmlTraits { }
    #endregion
}
