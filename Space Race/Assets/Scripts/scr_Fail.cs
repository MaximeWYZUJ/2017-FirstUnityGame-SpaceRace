using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Fail : MonoBehaviour {

	public GameObject inst_explosion;
	public GameObject Credits;

	private AudioSource AS;


	void Start () {
		AS = GetComponent <AudioSource> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Tag_BB" || other.gameObject.tag == "Tag_Sap" || other.gameObject.tag == "Tag_Poiss") {
			Debug.Log ("Defaite");
			Instantiate (inst_explosion, other.transform.position, Quaternion.identity);
			Instantiate (Credits);
			AS.Play ();
			//Destroy (this.gameObject);
		}
	}
}
