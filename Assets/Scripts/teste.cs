using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {


    private Transform t;
    public GameObject g;
    private float cooldown = 0.3f;
    private float nextfire = 0;

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("k"))
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKey("l") && Time.time > this.nextfire)
        {
            GameObject g2 = Instantiate(this.g);
            Transform t2 = g2.GetComponent<Transform>();
            t2.position = t.position;
            nextfire = Time.time + this.cooldown;
        }

    }
}
