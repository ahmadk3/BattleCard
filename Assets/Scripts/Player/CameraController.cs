using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Transform t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //t.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
	}
}
