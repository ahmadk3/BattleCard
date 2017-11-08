using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingEnemy : Player {

    private Transform t;
    private Rigidbody2D rb;
    private GameObject player;
    private float nextfire = 0.0f;
    public GameObject healthBarObject;
    private Image healthBar;
    private float nextHit = 0.0f;
    public float hitCooldown;
    public float damage;
    public GameObject projectile;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = healthBarObject.GetComponent<Image>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);

        healthBar.fillAmount = getHealthPercentage();
        if (this.health <= 0.0f)
        {
            Destroy(this.gameObject);
            GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
            gc.enemiesCount++;

			Player player = GameObject.Find("Player").GetComponent<Player>();
			if (player != null) {
				player.increaseScore (2);
			}
        }

        if (Vector3.Distance(player.transform.position, this.t.position) < 20)
        {
            Vector3 dir = (player.transform.position - this.t.position) * -1;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (Time.time > nextfire)
            {
                nextfire = Time.time + hitCooldown;

                GameObject g = Instantiate(this.projectile);
                g.active = true;
                Transform t = g.GetComponent<Transform>();
                Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
                //Vector3 force = new Vector3(10, 0, 0);
                rb.AddForce((player.transform.position - this.t.position) * 2, ForceMode2D.Impulse);
                //other.GetComponent<Rigidbody2D>().AddForce();
                t.position = this.t.position;
                t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }


    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {

       

    }
}
