using UnityEngine;
using System.Collections;

public class CardBoulder : Card
{

    public float speed = 70.0f;
    public GameObject player;

    private Rigidbody2D rb;
    private Transform t;
    private Animator anim;

    // Use this for initialization

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("player"), LayerMask.NameToLayer("Boulder"));

        this.cooldown = 1f;

        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Debug.Log(Time.deltaTime);
        rb.AddForce(new Vector3(1000f, 1f, 0.0f) * (t.rotation.y != 0.0f ? 1.0f : -1.0f) * -1);
        t.rotation = new Quaternion(0, player.transform.rotation.y, 0, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject, 1f);
            rb.velocity = rb.velocity / 50;
            Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector3 force = new Vector3(15, 0, 0) * (t.rotation.y != 0.0f ? -1.0f : 1.0f);
            otherRb.AddForce(force, ForceMode2D.Impulse);
            Player target = other.gameObject.GetComponent<Player>();
            target.health -= this.damage;
        }
        else if (other.tag.Equals("Floor") || other.tag.Equals("Wall"))
        {
            Destroy(this.gameObject, 0f);
        }
    }
}
