using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public int ItemID = 1000;
    public string ItemName;
    public uint Weight=1;


    public int getID()
    {
        return ItemID;
    }
    public string getItemName()
    {
        return ItemName;
    }
    public uint getWeight()
    {
        return Weight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //do something
            ;
            //Destroy(gameObject);
        }
    }

}
