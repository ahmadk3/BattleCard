using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : Player {

    private Image healthBar;
    public GameObject healthBarObject;

	// Use this for initialization
	void Start () {
        healthBar = healthBarObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = getHealthPercentage();

        if (this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
