using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    Sprite sprite;

    public Sprite GetItemSprite()
    {
        return sprite;
    }
}
