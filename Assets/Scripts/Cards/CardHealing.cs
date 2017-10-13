using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealing : Card {

	// Use this for initialization
	void Start () {
		this.cooldown = 1;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		
	}
}
