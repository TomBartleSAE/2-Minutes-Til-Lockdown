using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    Item itemType;

    ParticleSystem glow;

    private void Start()
    {
        glow = GetComponentInChildren<ParticleSystem>();
    }

    public Item GetItemType()
    {
        return itemType;
    }

    public void EnableGlow(bool enabled)
    {
        if (enabled)
        {
            glow.Play();
        }
        else
        {
            glow.Stop();
        }
    }
}
