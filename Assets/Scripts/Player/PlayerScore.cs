using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore  
{
	static public int score = 0;    // this is reachable from everywhere

	public static void increaseScore(int points) {
		PlayerScore.score += points;
	}
}
