using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Collision_obstacle : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (!(other.gameObject.tag == "Tag_Start")) {
			Destroy (this.gameObject);
		}
	}

}
