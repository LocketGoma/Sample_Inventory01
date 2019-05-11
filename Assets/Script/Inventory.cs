using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

   
    ItemNode[] ItemLoader;      //아이템 출력 순서... 써야되나?

    Dictionary<int, int> ItemCargo = new Dictionary<int, int>();      //아이템 개수 <key:ItemID,Value:Itemcount>
    Dictionary<int, ItemNode> ItemData = new Dictionary<int, ItemNode>();   //아이템 정보 (아이템 ID를 받으면 아이템 정보를 넘겨줌)
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
    public int GetItemCount(int ItemID)                     //이거로 호출하면 되자너 ㅡㅡ
    {
        if (ItemCargo.ContainsKey(ItemID) == true)
            return ItemCargo[ItemID];

        return 0;
    }
    public string GetItemData(int ItemID)
    {        
        return ItemData[ItemID].getName();       
    }
    public int FlushItem(int ItemID)
    {
        if (ItemCargo.ContainsKey(ItemID) == false)
            return -1;
        ItemCargo.Remove(ItemID);
        ItemData.Remove(ItemID);


        return ItemID;
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


}
