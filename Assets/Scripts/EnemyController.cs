using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Player
{
	// Use this for initialization
	void Start () {
        
	}

    private void Update()
    {
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
