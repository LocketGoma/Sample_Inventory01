using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventroy : MonoBehaviour {

    public GameObject InventoryUI;
    [Range(0,100)]
    public float UIspeed=25f;

    private bool isInventoryOpen = false;
    private float startPos;

	// Use this for initialization
	void Awake () {
        startPos = InventoryUI.transform.position.x;          //최대 이동거리 (현 위치)
        Debug.Log(startPos);

        InventoryUI.transform.position = new Vector3(InventoryUI.transform.position.x+150.0f, InventoryUI.transform.position.y, InventoryUI.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i") == true)
        {
            ToggleInventory();
        }

    }

    public void ToggleInventory()
    {
        if (isInventoryOpen==true)
        {
            InventoryClose();            
        }
        if (isInventoryOpen == false)
        {
            InventoryOpen();            
        }
    }

    private void InventoryOpen()
    {
        StartCoroutine("OpenUI");
    }
    private void InventoryClose()
    {
        StartCoroutine("CloseUI");
    }

    private IEnumerator OpenUI()
    {
        while (true)
        {
            InventoryUI.transform.position += new Vector3(-UIspeed, 0, 0);
            Debug.Log("Open" + InventoryUI.transform.position.x);
            yield return new WaitForFixedUpdate();
            if (InventoryUI.transform.position.x < startPos)
            {
                isInventoryOpen = true;
                yield break;
            }
        }
    }
    private IEnumerator CloseUI()
    {
        while (true)
        {
            InventoryUI.transform.position += new Vector3(UIspeed, 0, 0);
            Debug.Log("Close" + InventoryUI.transform.position.x);
            yield return new WaitForFixedUpdate();
            if (InventoryUI.transform.position.x > (startPos + 150.0f))
            {
                isInventoryOpen = false;
                yield break;
            }
        }
        
    }

}
