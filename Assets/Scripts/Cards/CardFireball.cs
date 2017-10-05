using UnityEngine;
using System.Collections;

public class CardFireball : Card {

    public float speed = 100.0f;
    public GameObject player;

    private Rigidbody2D rb;
    private Transform t;
    private Animator anim;
    
    // Use this for initialization

    void Start () {

        this.cooldown = 0.3f;

        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Debug.Log(Time.deltaTime);
        rb.velocity = (t.right * (t.rotation.y != 180.0f? 1.0f: -1.0f)) * speed * 0.015f;
        t.rotation = new Quaternion(0, player.transform.rotation.y, 0, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject, 1f);
            anim.SetBool("Hit", true);
            rb.velocity = rb.velocity/50;
            Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
            Vector3 force = new Vector3(5, 0, 0) * (t.rotation.y != 0.0f ? -1.0f : 1.0f);
            otherRb.AddForce(force, ForceMode2D.Impulse);
            Player target = other.GetComponent<Player>();
            target.health -= this.damage;
        }
        else if (other.tag.Equals("Floor") || other.tag.Equals("Wall"))
        {
            Destroy(this.gameObject, 1f);
            anim.SetBool("Hit", true);
            rb.velocity = rb.velocity / 50;
        }
    }
}
