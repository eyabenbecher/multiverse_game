using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        pistols,
        mele,
        rifles,
        snipers,

    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.pistols: return ItemAssets.Instance.pistolSprite;
            case ItemType.rifles: return ItemAssets.Instance.rifleSprite;
            case ItemType.snipers: return ItemAssets.Instance.sniperSprite;
            case ItemType.mele: return ItemAssets.Instance.meleSprite;
        }
    }
}
