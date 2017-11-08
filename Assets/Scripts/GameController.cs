﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int waves = 5;
    public int[] shooter;
    public int[] flying;
    public int enemiesCount = 0;
    private int[] enemiesPerWave;
    private int currentWave = 0;
    public GameObject flyingEnemy;
    public GameObject shootingEnemy;
	public Text scoreText;

	// Use this for initialization
	void Start () {
        enemiesPerWave = new int[waves];

        for(int i = 0; i < waves; i++)
        {
            enemiesPerWave[i] = enemiesPerWave[i > 0 ? i - 1 : 0] + shooter[i] + flying[i];
            print(enemiesPerWave[i]);
        }

        instantiateWave(0);
    }
	
	// Update is called once per frame
	void Update () {
		if(enemiesCount == enemiesPerWave[currentWave])
        {
            print("aee");
            instantiateWave(currentWave + 1);
            currentWave++;
        }
		updateScoreText ();
    }

	void updateScoreText() {
		int score = 0;
		Player player = GameObject.Find("Player").GetComponent<Player>();

		if (player != null) {
			score = player.score;
		}

		scoreText.text = "Score: " + score;
	}

    void instantiateWave(int waveNumber)
    {
        for (int j = 0; j < flying[waveNumber]; j++)
        {
            GameObject enemy = Instantiate(flyingEnemy);
            enemy.SetActive(true);
        }
        for (int j = 0; j < shooter[waveNumber]; j++)
        {
            GameObject enemy = Instantiate(shootingEnemy);
            enemy.SetActive(true);
        }
    }
}
