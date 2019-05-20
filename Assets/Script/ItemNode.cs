using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNode
{
    int ItemID;
    string ItemName;
    public uint Weight;

    public string getName() { return ItemName; }
    public uint getWeight() { return Weight;   }


    public ItemNode(int ItemID, string ItemName, uint Weight)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.Weight = Weight;
    }
    public ItemNode()
    {
        ;
    }
}