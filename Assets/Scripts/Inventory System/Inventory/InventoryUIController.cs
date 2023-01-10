using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{   
    public InventoryObject inventory;
    public static List<InventoryItemIcon> InventoryItems = new List<InventoryItemIcon>();
    public VisualTreeAsset sourceAsset;
    public ItemObject defaultItemObject;
    
    private VisualElement m_Root;
    private VisualElement m_SlotContainer;

    private static VisualElement m_GhostIcon;
    private static bool m_IsDragging;
    private static InventoryItemIcon m_OriginalSlot;
    private bool isActiveAsset;

    private void Awake()
    {
        VisualTreeAsset vt = GetComponent<UIDocument>().visualTreeAsset;

        if(vt != sourceAsset)
        {
            isActiveAsset = false;
            return;
        }

        //Store the root from the UI Document component
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        //Search the root for the SlotContainer Visual Element
        m_SlotContainer = m_Root.Q<VisualElement>("SlotContainer");
        //Create InventorySlots and add them as children to the SlotContainer
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventoryItemIcon item = new InventoryItemIcon();
            item.HoldItem(inventory.Container[i].item, inventory.Container[i].amount);
            InventoryItems.Add(item);
            m_SlotContainer.Add(item);
        }

        m_GhostIcon = m_Root.Query<VisualElement>("GhostIcon");
        m_GhostIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        m_GhostIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    public static void StartDrag(Vector2 position, InventoryItemIcon originalSlot)
    {
        if(originalSlot.item.type == ItemType.Default)
        {
            return;
        }

        //Set tracking variables
        m_IsDragging = true;
        m_OriginalSlot = originalSlot;
        //Set the new position
        m_GhostIcon.style.top = position.y - m_GhostIcon.layout.height / 2;
        m_GhostIcon.style.left = position.x - m_GhostIcon.layout.width / 2;
        //Set the image
        m_GhostIcon.style.backgroundImage = (StyleBackground)originalSlot.item.itemIcon;
        //Flip the visibility on
        m_GhostIcon.style.visibility = Visibility.Visible;
        
        Label amountText = (Label)m_GhostIcon.Q<VisualElement>("itemAmount");
        amountText.text = originalSlot.amount.ToString();
        amountText.AddToClassList("slotAmount");
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        //Only take action if the player is dragging an item around the screen
        if (!m_IsDragging)
        {
            return;
        }
        //Set the new position
        m_GhostIcon.style.top = evt.position.y - m_GhostIcon.layout.height / 2;
        m_GhostIcon.style.left = evt.position.x - m_GhostIcon.layout.width / 2;
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (!m_IsDragging)
        {
            return;
        }
        
        //Check to see if they are dropping the ghost icon over any inventory slots.
        IEnumerable<InventoryItemIcon> slots = InventoryItems.Where(x => x.worldBound.Overlaps(m_GhostIcon.worldBound));
        
        //Found at least one
        if (slots.Count() != 0)
        {
            InventoryItemIcon closestSlot = slots.OrderBy(x => Vector2.Distance
            (x.worldBound.position, m_GhostIcon.worldBound.position)).First();
            
            //Set the new inventory slot with the data
            closestSlot.HoldItem(m_OriginalSlot.item, m_OriginalSlot.amount);
            
            if(closestSlot != m_OriginalSlot)
            {

                for (int i = 0; i < InventoryItems.Count; i++)
                {
                    inventory.SetToEmptyObject(m_OriginalSlot.item);  
                }
                m_OriginalSlot.HoldItem(defaultItemObject, 0);
            }

        }
        //Didn't find any (dragged off the window)
        else
        {
            m_OriginalSlot.icon.image = m_OriginalSlot.item.itemIcon;
        }

        //Clear dragging related visuals and data
        m_IsDragging = false;
        m_OriginalSlot = null;
        m_GhostIcon.style.visibility = Visibility.Hidden;
    }

}
