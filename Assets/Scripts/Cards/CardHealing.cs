using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealing : Card {

	public int healthPoints;

	// Use this for initialization
	void Start () {
		this.cooldown = 1;

		Player player = GameObject.Find ("Player").GetComponent<Player> ();
		if (player != null) {
			player.health += healthPoints;
		}
	}
}
