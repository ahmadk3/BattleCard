using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealing : Card {

	private int healthPoints;

	// Use this for initialization
	void Start () {
		this.cooldown = 1;
		this.healthPoints = 10;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D() {
		GameObject playerObj = GameObject.FindWithTag("Player");
		Player player = playerObj.GetComponent<Player>();

		if (player != null) {
			player.health -= this.healthPoints;
		}
	}
}
