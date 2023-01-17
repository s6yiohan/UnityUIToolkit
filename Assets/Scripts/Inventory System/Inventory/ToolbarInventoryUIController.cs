using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolbarInventoryUIController : MonoBehaviour
{
    private VisualElement m_Root;
    private VisualElement m_SlotContainer;
    private bool isActiveAsset;

    private List<HUDToolbarItemIcon> toolbarItems = new List<HUDToolbarItemIcon>();

    private enum toolBarSlot{

    }


    private void Update() {
        if(Input.anyKey)
        {
            for(KeyCode i = KeyCode.Alpha1; i <= KeyCode.Alpha9; i++){
                if(Input.GetKeyDown(i)){
                    int itemIndex = (int)KeyCode.Alpha1 - (int)i;
                    
                    if(-itemIndex < toolbarItems.Count)
                    {
                        SelectItemOnToolbar(-itemIndex);
                    }
                }
            }
        }
    }

    private void SelectItemOnToolbar(int p_itemIndex)
    {
        foreach(HUDToolbarItemIcon item in toolbarItems)
        {
            item.Unselected();
        }

        toolbarItems[p_itemIndex].Selected();
    }


    public void Load() {
        
        VisualTreeAsset vt = GetComponent<UIDocument>().visualTreeAsset;

        m_Root = GetComponent<UIDocument>().rootVisualElement;        
        
        m_SlotContainer = m_Root.Q<VisualElement>("SlotContainer");
        toolbarItems.Clear();

        for (int i = 0; i < 7; i++)
        {
            InventoryItemIcon inventoryItem = InventoryUIContainer.Instance.InventoryItems[i];
            HUDToolbarItemIcon toolbarIcon = new HUDToolbarItemIcon();
            
            if(inventoryItem.item != null)
            {
                toolbarIcon.HoldItem(inventoryItem.item, inventoryItem.amount);
            }
            
            m_SlotContainer.Add(toolbarIcon);
            toolbarItems.Add(toolbarIcon);
        }

    }
}
