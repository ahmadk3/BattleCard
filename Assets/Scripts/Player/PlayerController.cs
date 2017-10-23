using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.UIElements;

public class PlayerController : Player {

	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

	bool isDead;                                                // Whether the player is dead.
	bool damaged; 



    public float jumpSpeed = 5.0f;
    public float firerate = 0.3f;

    private Rigidbody2D rb;
    private Transform t;
    private float nextfire = 0.0f;
    private bool isGrounded = false;

    public List<GameObject> objects = new List<GameObject>();
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * this.speed;
        transform.position += move * Time.deltaTime;

        if (Input.GetKey("a"))
        {
            t.rotation = Quaternion.Euler(0, 180.0f, 0);
        }
        if (Input.GetKey("d"))
        {
            t.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("w") && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Floor") || other.gameObject.tag.Equals("Platform"))
            isGrounded = true;
    }   

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Floor") || other.gameObject.tag.Equals("Platform"))
            isGrounded = false;
    }
}
