using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolbarInventoryUIController : MonoBehaviour
{
    public VisualTreeAsset sourceAsset;

    private VisualElement m_Root;
    private VisualElement m_SlotContainer;
    private bool isActiveAsset;

    private void Awake() {
        
        VisualTreeAsset vt = GetComponent<UIDocument>().visualTreeAsset;

        if(vt != sourceAsset)
        {
            isActiveAsset = false;
            return;
        }

        m_Root = GetComponent<UIDocument>().rootVisualElement;        
        
        m_SlotContainer = m_Root.Q<VisualElement>("SlotContainer");

        for (int i = 0; i < 8; i++)
        {
            m_SlotContainer.Add(InventoryUIController.InventoryItems[i]);
        }
    }
}
