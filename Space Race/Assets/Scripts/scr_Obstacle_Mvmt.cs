using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Obstacle_Mvmt : MonoBehaviour {

	public float VitesseMoy;
	public float Ecart;

	private float Vitesse;
	private Rigidbody rb;
	private Transform tr;
	private Vector3 V_Move;
	private Vector3 V_Pos;


	void Start ()
	{
		Vitesse = VitesseMoy - Ecart + Random.value * 2 * Ecart;
		rb = GetComponent <Rigidbody> ();
		tr = GetComponent <Transform> ();
		V_Move = new Vector3 (Vitesse, 0, 0);
	}


	void Update ()
	{
		rb.AddForce (V_Move);

		V_Pos = tr.position;
		if (V_Pos.x > 40f) {
			Destroy (this.gameObject);		// l'obstacle n'est plus visible
		}
	}
}
