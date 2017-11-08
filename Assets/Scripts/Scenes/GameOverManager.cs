using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Text text;
	float timeLeft = 5.0f;

	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "Voltando para o menu em: " + Mathf.Round(timeLeft) + "s";
		if(timeLeft <= 0)
		{
			new SwitchScene().loadScene ("Menu");
		}
	}
}
