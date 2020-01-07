using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Gestion : MonoBehaviour {

	public AudioClip Son1;
	public AudioClip Son2;
	public AudioClip Son3;
	private AudioSource AS;
	private float nb;


	void Start () {
		AS = GetComponent <AudioSource> ();
		nb = Mathf.Ceil (3 * Random.value);
		if (nb == 1) {
			AS.clip = Son1;
		} else if (nb == 2) {
			AS.clip = Son2;
		} else AS.clip = Son3;


	}

}
