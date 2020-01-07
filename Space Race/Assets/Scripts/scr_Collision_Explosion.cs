using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Collision_Explosion : MonoBehaviour {

	private Transform tr;
	public GameObject inst_explosion;
	private Vector3 V_Pos;


	void Start () {
		tr = GetComponent <Transform> ();
	}

	void Update () {
		V_Pos = tr.position;
	}

	void OnTriggerEnter (Collider other) {
		Instantiate (inst_explosion, V_Pos, Quaternion.identity);
		Destroy (this.gameObject);
	}
}
