using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCardArrow : MonoBehaviour {

    private FixedJoint2D fj;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
        fj = GetComponent<FixedJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")){
            //this.bc.enabled = false;
            
            this.rb.mass = 0.0001f;
            this.fj.enabled = true;
            this.fj.connectedBody = collision.GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, 2.0f);
            collision.GetComponent<Rigidbody2D>().AddForce(this.rb.velocity * 10);
            this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = 0.0f;
        }
    }
}
