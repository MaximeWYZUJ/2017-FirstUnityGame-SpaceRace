using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Victory : MonoBehaviour {

	public GameObject Credits;

	private AudioSource AS;


	void Start () {
		AS = GetComponent <AudioSource> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Tag_BB" || other.gameObject.tag == "Tag_Sap" || other.gameObject.tag == "Tag_Poiss") {
			Debug.Log ("Victoire");
			Instantiate (Credits);
			AS.Play ();
			//Destroy (this.gameObject);
		}
	}
}
