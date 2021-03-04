using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    Item itemType;

    public Item GetItemType()
    {
        return itemType;
    }
}
