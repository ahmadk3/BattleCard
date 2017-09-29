using UnityEngine;
using System.Collections;

public class CardLightning : Card {

    public GameObject lightning;

    private Transform t;

    private int i = 0;
	// Use this for initialization
	void Start () {
        cooldown = 1;
        t = GetComponent<Transform>();
        t.position += new Vector3(1, 1, 1);
        t.position -= new Vector3(1, 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        i++;

        if (i >= 1)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {        
            GameObject go = (GameObject)Instantiate(lightning, other.transform.position + new Vector3(0, 1, -1), new Quaternion(0, 0, 0, 0));
            go.SetActive(true);
            Destroy(go, 2.0f);
            Player target = other.GetComponent<Player>();
            target.health -= this.damage;
        }
        
    }
}
