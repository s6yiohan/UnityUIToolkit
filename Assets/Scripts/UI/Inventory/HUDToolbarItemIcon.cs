using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class HUDToolbarItemIcon : InventoryItemIcon
{
    private StyleColor unselectedColor = new StyleColor();
    private void OnEnable() {
        unselectedColor = this.style.backgroundColor;
    }

    public void Selected(){
        this.style.backgroundColor = Color.green;
    }

    public void Unselected()
    {
        this.style.backgroundColor = Color.black;
    }

    protected override void OnPointerDown(PointerDownEvent evt)
    {

    }
}
