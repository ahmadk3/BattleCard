using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Player {

    public float jumpSpeed = 5.0f;
    public float firerate = 0.3f;
    public GameObject fireball;

    private Rigidbody2D rb;
    private Transform t;
    private float nextfire = 0.0f;
    private bool isGrounded = false;

    public List<GameObject> objects = new List<GameObject>();
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * this.speed;
        transform.position += move * Time.deltaTime;

        if (Input.GetKey("a"))
        {
            t.rotation = Quaternion.Euler(0, 180.0f, 0);
        }
        if (Input.GetKey("d"))
        {
            t.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("w") && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Floor"))
            isGrounded = true;
    }


   
    

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Floor"))
            isGrounded = false;
    }
}
