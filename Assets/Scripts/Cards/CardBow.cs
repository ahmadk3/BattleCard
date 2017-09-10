using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBow : MonoBehaviour {
    public GameObject arrow;
    public float cooldown = 1f;

    private Transform t;
    private float nextfire = 0.0f;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);
    }

    void OnTriggerStay2D(Collider2D other){

        if (other.CompareTag("Enemy") && Time.time > nextfire )
        {
            nextfire = Time.time + cooldown;

            GameObject g = Instantiate(this.arrow);
            g.active = true;
            Transform t = g.GetComponent<Transform>();
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            //Vector3 force = new Vector3(10, 0, 0);
            rb.AddForce((other.transform.position - this.t.position) * 5, ForceMode2D.Impulse);
            t.position = this.t.position;
            //t.LookAt(other.GetComponent<Transform>());

        }

    }
}
