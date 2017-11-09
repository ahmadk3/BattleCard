using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int waves = 100;
    public int enemiesCount = 0;
    private int[] enemiesPerWave;
    private int currentWave = 0;
    public GameObject flyingEnemy;
    public GameObject shootingEnemy;
	public Text scoreText;
    public Transform[] spawns = new Transform[7]; 

	// Use this for initialization
	void Start () {
		PlayerScore.score = 0;
        enemiesPerWave = new int[waves];

        for(int i = 0; i < waves; i++)
        {
            enemiesPerWave[i] = enemiesPerWave[i > 0 ? i - 1 : 0] + i+1 + i+1;
        }

        instantiateWave(0);
    }
	
	// Update is called once per frame
	void Update () {
		if(enemiesCount == enemiesPerWave[currentWave])
        {
            instantiateWave(currentWave + 1);
            currentWave++;
        }
		updateScoreText ();
    }

	void updateScoreText() {
		int score = PlayerScore.score;
		scoreText.text = "Score: " + score;
	}

    void instantiateWave(int waveNumber)
    {

//		TODO: add some SoundEffect in a new wave of enemies
//		SoundManager.Instance.PlayOneShot(SoundManager.Instance.winSound);

        for (int j = 0; j <= waveNumber; j++)
        {
            GameObject enemy = Instantiate(flyingEnemy, spawns[Random.Range(0, 6)]);
            enemy.SetActive(true);
        }
        for (int j = 0; j <= waveNumber; j++)
        {
            GameObject enemy = Instantiate(shootingEnemy, spawns[Random.Range(0, 6)]);
            enemy.SetActive(true);
        }
    }
}
