using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBow : Card {
    public GameObject arrow;
    public float arrowCooldown = 1f;

    private Transform t;
    private float nextfire = 0.0f;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        Destroy(this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);
    }

    void OnTriggerStay2D(Collider2D other){

        if (other.CompareTag("Enemy") && Time.time > nextfire )
        {
            nextfire = Time.time + arrowCooldown;

            GameObject g = Instantiate(this.arrow);
            g.active = true;
            Transform t = g.GetComponent<Transform>();
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            //Vector3 force = new Vector3(10, 0, 0);
            rb.AddForce((other.transform.position - this.t.position) * 5, ForceMode2D.Impulse);
            t.position = this.t.position;

            Vector3 dir = (other.transform.position - this.t.position) * -1;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //t.LookAt(other.GetComponent<Transform>());

        }

    }
}
