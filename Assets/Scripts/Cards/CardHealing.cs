using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealing : Card {

	public int healthPoints;

	void Start () {
		Player player = GameObject.Find("Player").GetComponent<Player>();

		if (player != null) {
			player.health = Mathf.Min(player.health + healthPoints, player.maxHealth);
		}

		Destroy(this.gameObject);
	}
}