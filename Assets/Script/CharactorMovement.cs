using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMovement : MonoBehaviour {

    [Header("Speed&power")]
    public float MoveSpeed = 10f;
    public float JumpPower = 10f;


    [Header("Optional value")]
    public GameObject Player;
    [SerializeField] private bool JumpStatus = false;
    private int direction = 0;  // 0 : 좌-> 우 / 1 : 우->좌
    private Rigidbody2D Rbody;
    private Animator Animator;
    private float speedGap = 100;
    private bool rightlock = false;
    private bool leftlock = false;
    private Vector2 JumpVelocity;


    // Use this for initialization
    void Start () {
        Rbody = gameObject.GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponentInChildren<Animator>();
        JumpVelocity = new Vector2(0, JumpPower);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("right"))
        {
            rightlock = true;
            leftlock = false;
            this.MoveRight();
        }
        if (Input.GetKeyDown("left"))
        {
            rightlock = false;
            leftlock = true;
            this.MoveLeft();
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            rightlock = false;
            leftlock = false;
        }
        if (Input.GetKeyDown("space")&& JumpStatus==false)
        {
            Rbody.AddForce(JumpVelocity, ForceMode2D.Impulse);
            JumpStatus = true;
            StartCoroutine("JumpRelease");
        }


        if (rightlock == true)
        {
            this.MoveRight();
        }
        if (leftlock == true)
        {
            this.MoveLeft();
        }
    }

    private void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + MoveSpeed / speedGap, transform.position.y, transform.position.z);
    }
    private void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - MoveSpeed / speedGap, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BaseFloor")
        {
            JumpStatus = false;
            StopCoroutine("JumpRelease");
        }
    }
    private IEnumerator JumpRelease()
    {
        yield return new WaitForSeconds(3);
        JumpStatus = false;
        StopCoroutine("JumpRelease");
    }

}
