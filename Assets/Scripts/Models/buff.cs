using UnityEngine;
using System.Collections;

public class Buff : MonoBehaviour {

	public string name;
	public float value;
	public float bonusMultiplier;
	public float bonusValue;

	Buff(string name, float value){
		this.name = name;
		this.value = value;
	}
}
