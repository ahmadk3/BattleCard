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
    }

    // Update is called once per frame
    void Update() {
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);
        t.position = t.position + new Vector3(0.0f, Mathf.Sin(Time.time * 3), 0.0f) / 20;

        rb.AddForce(player.transform.position - transform.position);

        healthBar.fillAmount = getHealthPercentage();
        if (this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, -17, 17f);
        // re-assigning the transform's position will clamp it
        transform.position = clampedPosition;
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
            Physics2D.IgnoreLayerCollision(11, 9, true);
            if (Time.time >= nextHit)
            {
                nextHit = Time.time + hitCooldown;
                Player player = other.gameObject.GetComponent<Player>();
                player.health -= damage;
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Physics2D.IgnoreLayerCollision(11, 9, false);
        }
    }
}
