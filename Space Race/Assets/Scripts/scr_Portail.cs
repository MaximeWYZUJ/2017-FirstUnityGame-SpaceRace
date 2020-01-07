using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Portail : MonoBehaviour {

	public float Temps_Jusque_Calibrage;
	public float Duree_Calibrage;
	public float Distance_Calibrage;

	private Transform tr;
	private Vector3 V_Move;
	private Vector3 V_Move_Calibrage;
	private float Vitesse;
	private float Vitesse_Calibrage;
	private bool stop;


	void Start () {
		tr = GetComponent <Transform> ();
		Vitesse = (Mathf.Abs (tr.position.x) - Distance_Calibrage) / (60 * Temps_Jusque_Calibrage);		// v=distance/temps de trajet
		Vitesse_Calibrage = Distance_Calibrage / (60 * Duree_Calibrage);
		V_Move = new Vector3 (1, 0, 0) * Vitesse;
		V_Move_Calibrage = new Vector3 (1, 0, 0) * Vitesse_Calibrage;
		stop = false;
	}
	

	void Update () {
		if (!stop) {
			if (Mathf.Abs (tr.position.x) > Distance_Calibrage) {
				//Déplacement du portail :
				tr.position = tr.position + V_Move;
			} else if (tr.position.x < 15) {
				//Phase courte de calibrage
				tr.position = tr.position + V_Move_Calibrage;
			} else {
				tr.position = new Vector3 (-7, 0, 0);
				tr.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				stop = true;
			}
		}
	}
}
