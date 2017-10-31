using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealing : Card {

	public int healthPoints;

	// Use this for initialization
	void Start () {
		Debug.Log ("START");
		Player player = GameObject.Find("Player").GetComponent<Player>();
		Debug.Log("PLAYER", player);
		if (player != null) {
//			Debug.Log("PLAYER != NULL", player != null );	
			player.health = Mathf.Min(player.health + healthPoints, player.maxHealth);
		}
		Destroy(this.gameObject);
	}
}