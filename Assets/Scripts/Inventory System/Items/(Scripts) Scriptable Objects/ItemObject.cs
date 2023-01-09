using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType{
    Food,
    Equipment,
    Default
}


public class ItemObject : ScriptableObject
{
    public Texture itemIcon;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;

}
