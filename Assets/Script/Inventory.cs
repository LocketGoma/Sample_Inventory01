using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    class ItemNode
    {
        int ItemID;
        string ItemName;

        public string getName() {return ItemName;}

        public ItemNode(int ItemID,string ItemName)
        {
            this.ItemID =ItemID;
            this.ItemName =ItemName;
        }
        public ItemNode()
        {
            ;
        }        
    }
    ItemNode[] ItemLoader;      //아이템 출력 순서... 써야되나?

    Dictionary<int, int> ItemCargo = new Dictionary<int, int>();      //아이템 개수 <key:ItemID,Value:Itemcount>
    Dictionary<int, ItemNode> ItemData = new Dictionary<int, ItemNode>();

    public void Update()
    {
        if (Input.GetKeyDown("i") == true)
        {
            string ans="";
            foreach(KeyValuePair<int,int> temp in ItemCargo)
            {
                ans += "Item [" + ItemData[temp.Key].getName() + "] are [" + temp.Value + "]in cargo \n";
            }
            Debug.Log(ans);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     if (other.gameObject.tag == "Item")
        {
            int ItemID = other.GetComponent<Item>().getID();
            if (ItemCargo.ContainsKey(ItemID) == true)
            {
                ItemCargo[ItemID]++;
            }
            else
            {
                ItemCargo.Add(ItemID, 1);
                ItemNode inputNode = new ItemNode(ItemID, other.GetComponent<Item>().getItemName());
                ItemData.Add(ItemID, inputNode);
            }
        }
        

    }
    public int getItemCount(int ItemID)
    {
        if (ItemCargo.ContainsKey(ItemID) == true)
        return ItemCargo[ItemID];

        return 0;
    }

}
