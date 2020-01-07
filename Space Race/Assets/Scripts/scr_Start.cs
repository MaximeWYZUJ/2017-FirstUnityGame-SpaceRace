using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Start : MonoBehaviour {

	private Transform tr;


	void Start () {
		tr = GetComponent <Transform> ();
		tr.Rotate (new Vector3 (80, 90, 0));
	}

	void OnTriggerEnter (Collider other) {
		this.name = "Start Pressed";
	}
}
