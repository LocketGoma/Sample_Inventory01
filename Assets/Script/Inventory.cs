using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [Header("Inventory Cargo")]
    [Range(-1, 100)]
    public int ItemCargoSize = 10;      // -1 = 무한대
    private int nowCargeSize = 0;
   
    ItemNode[] ItemLoader;      //아이템 출력 순서... 써야되나?

    Dictionary<int, int> ItemCargo = new Dictionary<int, int>();      //아이템 개수 <key:ItemID,Value:Itemcount>
    Dictionary<int, ItemNode> ItemData = new Dictionary<int, ItemNode>();   //아이템 정보 (아이템 ID를 받으면 아이템 정보를 넘겨줌)

    private bool keyDown = false;
    
    public void Update()
    {   
        if (Input.GetKeyDown("i") == true)
        {
            string ans="";
            foreach(KeyValuePair<int,int> temp in ItemCargo)
            {
                ans += "Item [" + ItemData[temp.Key].getName() + "] are [" + temp.Value + "]in cargo \n";
            }
            Debug.Log(ans + "\n Weight : " + nowCargeSize + "/" + ItemCargoSize);       // (ItemCargoSize == -1 ? "∞" : ItemCargoSize)
        }
        if (Input.anyKeyDown == true)
        {
            keyDown = true;
        }
    }
    public void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey&&keyDown)
        {
            UseItem(e.keyCode);
            keyDown = false;
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
        //Debug.Log("Key:" + ItemID);
        if (ItemCargo.ContainsKey(ItemID) == true)
        {
            ItemCargo.Remove(ItemID);
            ItemData.Remove(ItemID);
            //Debug.Log("Key:" + ItemID);

            return ItemID;
        }

        return -1;
    }
    public void UseItem(KeyCode keyInput)          //되~게 비효율적인 방법같은데
    {   
        int input = NumKeyReturn(keyInput);
        int i = 0;        
        foreach (KeyValuePair<int, int> temp in ItemCargo)
        {
            i++;
            if (i == input)
            {
                Debug.Log("Using " + ItemData[temp.Key].getName() + ", left : " + (temp.Value-1));               
                DecreaseItem(temp.Key);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Item tempNode = other.GetComponent<Item>();
            if (nowCargeSize + (int)tempNode.getWeight() < ItemCargoSize || ItemCargoSize == -1) {
                int ItemID = tempNode.getID();
                if (ItemCargo.ContainsKey(ItemID) == true)
                {
                    ItemCargo[ItemID]++;
                }
                else
                {
                    ItemCargo.Add(ItemID, 1);
                    ItemNode inputNode = new ItemNode(ItemID, tempNode.getItemName(), tempNode.getWeight());
                    ItemData.Add(ItemID, inputNode);
                }
                nowCargeSize += (int)tempNode.getWeight();
                Destroy(other.gameObject);
            }
        }
    }

    private int DecreaseItem(int ItemID)
    {
        //Debug.Log("Key:" + ItemID);
        //Debug.Log("loose Weight" + ItemData[ItemID].getWeight());
        nowCargeSize -= (int)ItemData[ItemID].getWeight();
        if (ItemCargo[ItemID] == 1)
        {
            return FlushItem(ItemID);
        }
        return ItemCargo[ItemID]--;
    }


    private int NumKeyReturn(KeyCode keyInput)
    {
        
        switch (keyInput)
        {
        case KeyCode.Alpha1:
            {
                return 1;
            }
        case KeyCode.Keypad1:
            {
                return 1;                    
            }
        case KeyCode.Alpha2:
            {
                return 2;
            }
        case KeyCode.Keypad2:
            {
                return 2;
            }
        case KeyCode.Alpha3:
            {
                return 3;
            }
        case KeyCode.Keypad3:
            {
                return 3;
            }
        case KeyCode.Alpha4:
            {
                return 4;
            }
        case KeyCode.Keypad4:
            {
                return 4;
            }
        case KeyCode.Alpha5:
            {
                return 5;
            }
        case KeyCode.Keypad5:
            {
                return 5;
            }
        case KeyCode.Alpha6:
            {
                return 6;
            }
        case KeyCode.Keypad7:
            {
                return 7;
            }
        case KeyCode.Alpha8:
            {
                return 8;
            }
        case KeyCode.Keypad9:
            {
                return 9;
            }
        case KeyCode.Alpha0:
            {
                return 0;
            }
        default:
            {
                return 0;
            }
        }
    }



}
