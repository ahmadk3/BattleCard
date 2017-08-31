using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	//Stats
	public float health;
	public Buff healtBuff;
	public float hps;
	public Buff hpsBuff;
	public float mana;
	public Buff manaBuff;
	public float MPS;
	public Buff mpsBuff;
	public float attackDamage;
	public Buff attackDamageBuff;
	public int jumps;
	public Buff jumpsBuff;
	public float speed;
	public Buff speedBuff;

	public string team;
	public List<GameObject> cards = new List<GameObject>();


}
