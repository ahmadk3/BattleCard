using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingEnemy : Player{

    private Transform t;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject healthBarObject;
    private Image healthBar;

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = healthBarObject.GetComponent<Image>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreLayerCollision(10, 9);
    }
	
	// Update is called once per frame
	void Update () {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);
        t.position = t.position + new Vector3(0.0f, Mathf.Sin(Time.time * 3), 0.0f) / 20;

        rb.AddForce(player.transform.position - transform.position);

        healthBar.fillAmount = getHealthPercentage();
        if (this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
