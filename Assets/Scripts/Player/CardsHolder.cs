using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardsHolder : MonoBehaviour {

    public GameObject[] cards = new GameObject[5];

	public Rect LifeBar;
//	public Text timeTextFireball;
    private Transform t;
    private Rigidbody rb;
	public Slider ManaBar;
	private float[] nextfire = new float[5];
//	private float[] manaCost = new float[4];

	// Use this for initialization
	void Start () {
		
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        for(int i = 0; i < 5; i++)
        {
            nextfire[i] = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
		// TODO: create function to DRY this code, even if it is temporary
        if(Input.GetKey(KeyCode.Space))
        {
            if(cards[0] != null && Time.time > nextfire[0])
            {
                GameObject card = (GameObject)Instantiate(cards[0], t.position, t.rotation);
                nextfire[0] = Time.time + card.GetComponent<Card>().cooldown;
				ManaBar.value -= card.GetComponent<Card>().cost;
                card.SetActive(true);
            }
                
        }

        else if (Input.GetKey("2"))
        {
			
            if (cards[1] != null && Time.time > nextfire[1])
            {
//				timeTextFireball.text = "0";
                GameObject card = (GameObject)Instantiate(cards[1], t.position, t.rotation);
                nextfire[1] = Time.time + card.GetComponent<Card>().cooldown;
				ManaBar.value -= card.GetComponent<Card> ().cost;
                card.SetActive(true);
            }
        }

        else if (Input.GetKey("3") && Time.time > nextfire[2])
        {
            GameObject card = (GameObject)Instantiate(cards[2], t.position, t.rotation);
            nextfire[2] = Time.time + card.GetComponent<Card>().cooldown;
			ManaBar.value -= card.GetComponent<Card> ().cost;
            card.SetActive(true);
        }

        else if (Input.GetKey("4") && Time.time > nextfire[3])
        {
            GameObject card = (GameObject)Instantiate(cards[3], t.position, t.rotation);
            nextfire[3] = Time.time + card.GetComponent<Card>().cooldown;
			ManaBar.value -= card.GetComponent<Card> ().cost;
            card.SetActive(true);
        }

		else if (Input.GetKey("5") && Time.time > nextfire[4])
		{
			// HEALING
			GameObject card = (GameObject)Instantiate(cards[4], t.position, t.rotation);
			nextfire[4] = Time.time + card.GetComponent<Card>().cooldown;
			ManaBar.value -= card.GetComponent<Card> ().cost;
			card.SetActive(true);
		}
    }
}
