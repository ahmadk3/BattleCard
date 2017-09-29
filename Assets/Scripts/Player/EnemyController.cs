using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Player {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
