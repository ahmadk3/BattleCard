using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsHolder : MonoBehaviour {

    public GameObject[] cards = new GameObject[4];

    private Transform t;
    private Rigidbody rb;

    private float[] nextfire = new float[4];

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        for(int i = 0; i < 4; i++)
        {
            nextfire[i] = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKey(KeyCode.Space))
        {
            if(cards[0] != null && Time.time > nextfire[0])
            {
                GameObject card = (GameObject)Instantiate(cards[0], t.position, t.rotation);
                nextfire[0] = Time.time + card.GetComponent<Card>().cooldown;
                card.SetActive(true);
            }
                
        }

        else if (Input.GetKey("2"))
        {
            
            if (cards[1] != null && Time.time > nextfire[1])
            {
                GameObject card = (GameObject)Instantiate(cards[1], t.position, t.rotation);
                nextfire[1] = Time.time + card.GetComponent<Card>().cooldown;
                card.SetActive(true);
            }
        }

        else if (Input.GetKey("3"))
        {
            GameObject card = (GameObject)Instantiate(cards[2], t.position, t.rotation);
            nextfire[2] = Time.time + card.GetComponent<Card>().cooldown;
            card.SetActive(true);
        }

        else if (Input.GetKey("4"))
        {
            GameObject card = (GameObject)Instantiate(cards[3], t.position, t.rotation);
            nextfire[3] = Time.time + card.GetComponent<Card>().cooldown;
            card.SetActive(true);
        }
    }
}
