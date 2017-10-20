using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingEnemy : Player {

    private Transform t;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject healthBarObject;
    private Image healthBar;
    private float nextHit = 0.0f;
    public float hitCooldown;
    public float damage;

    // Use this for initialization
    void Start() {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = healthBarObject.GetComponent<Image>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreLayerCollision(10, 9);
        Physics2D.IgnoreLayerCollision(11, 9, true);
    }

    // Update is called once per frame
    void Update() {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);

        healthBar.fillAmount = getHealthPercentage();
        if (this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }

        Vector3 clampedPosition = transform.position;
        transform.position = clampedPosition;
    }

    void FixedUpdate()
    {
        t.position = Vector3.MoveTowards(t.position, player.transform.position, 0.15f);
        t.position = t.position + new Vector3(Mathf.Sin(Time.time * 10), Mathf.Sin(Time.time * 5), 0.0f) / 20;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player") && Time.time >= nextHit)
        {
            nextHit = Time.time + hitCooldown;
            Player player = other.gameObject.GetComponent<Player>();
            player.health -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (Time.time >= nextHit)
            {
                nextHit = Time.time + hitCooldown;
                Player player = other.gameObject.GetComponent<Player>();
                player.health -= damage;
                Debug.Log("hit");
            }

        }
    }
}
