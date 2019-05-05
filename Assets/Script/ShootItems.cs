using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//http://www.gisdeveloper.co.kr/?p=217
public class ShootItems : MonoBehaviour {

    [Header("PowerData")]
    [Range(0, 25)]
    public int SelectedPower;       //발사되는 힘
    [Range(0, 100)]
    public float variance;          //발사 힘 분산도  (분산, 표준분포를 따름)
    [Range(0, 180)]
    public float axis;              //0~180     (좌측/우측)

    [Header("ETC")]
    int RAND_MAX = 0x7fff;
    public GameObject[] Items;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int launchpower=NDRandom(0, (int)variance * 100, SelectedPower);
           // Debug.Log(launchpower);
            
            ItemIaunch(launchpower);
        }
    }
    private void ItemIaunch(int launchpower)
    {
        float ang = AxisRandom();
        Vector2 angler = (Vector2)(Quaternion.Euler(0, 0, ang) * Vector2.up);
        //Vector3 fireangle = new Vector3(angler.x, angler.y, transform.rotation.z);


        //Debug.Log("angle:"+angler+","+ ang);

        //Debug.Log(angler);
        GameObject LaunchedItem = Instantiate(Items[Random.Range(0, Items.Length)], new Vector3(transform.position.x, transform.position.y,-0.1f), transform.rotation);
        LaunchedItem.GetComponent<Rigidbody2D>().AddForce(angler * launchpower * 10);
        

    }
    private float AxisRandom()
    {        
        return Random.Range(-axis, axis);
    }

    int NDRandom(int start, int end, int level)    //start<=x<=end
    {
        if (level < 1)
            level = 1;
        double result = 0;

        for (int i = 0; i < level; i++)
        {
            result += (double)Random.Range(start, end) / (double)RAND_MAX;
            result /= (double)level;
        }
        return (int)(result * (end - level) + level);
    }

}

