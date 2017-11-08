using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Text text;
	float timeLeft = 5.0f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "Voltando para o menu em: " + Mathf.Round(timeLeft) + "s";
		if(timeLeft <= 0)
		{
			SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		}
	}
}
