using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Vaisseau_Controls : MonoBehaviour {

	public float F_Move;
	public float F_Rotation;
	public float F_Gravity;
	public float Distance_Max;
	public float AccRot_Max;
	public float AccRot_Aug;
	public float AccRot_Dim;
	public float Attenuation_Angulaire;
	public Transform tr1;
	public Transform tr2;
	public Transform tr3;
	public Transform tr4;

	private Rigidbody rb;
	private Transform tr;
	private Vector3 V_Move;
	private Vector3 V_AxeX;
	private Vector3 Vecteur_Nul;
	private float Distance;
	private float Div_Nb_React;
	private float Rot;
	private float AccRot1;
	private float AccRot2;
	private float AccRot3;
	private float AccRot4;


	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
		tr = GetComponent <Transform> ();
		Vecteur_Nul = new Vector3 (0f, 0f, 0f);
		V_AxeX = new Vector3 (1, 0, 0);
		Div_Nb_React = 0f;
		AccRot1 = 0;
		AccRot2 = 0;
		AccRot3 = 0;
		AccRot4 = 0;
	}

	void Update ()
	{
		Div_Nb_React = 0;
		if (tr1 != null) {
			Div_Nb_React = Div_Nb_React + 1;

			Rot = Input.GetAxis ("J1_GTrigger");
			if (Rot > 0.01f) {
				if (AccRot1 < Rot) {
					AccRot1 = Rot;
				} else {
					AccRot1 = AccRot1 * AccRot_Aug;
				}
			} else {
				AccRot1 = AccRot1 * AccRot_Dim;
			}
			if (AccRot1 > AccRot_Max) {
				AccRot1 = AccRot_Max;
			}
			tr.RotateAround (tr.position, V_AxeX, - (Rot + 1) * F_Rotation * AccRot1);
		}

		if (tr2 != null) {
			Div_Nb_React = Div_Nb_React + 1;

			Rot = Input.GetAxis ("J1_DTrigger");
			if (Rot > 0.01f) {
				if (AccRot2 < Rot) {
					AccRot2 = Rot;
				} else {
					AccRot2 = AccRot2 * AccRot_Aug;
				}
			} else {
				AccRot2 = AccRot2 * AccRot_Dim;
			}
			if (AccRot2 > AccRot_Max) {
				AccRot2 = AccRot_Max;
			}
			tr.RotateAround (tr.position, V_AxeX, (Rot + 1) * F_Rotation * AccRot2);
		}

		if (tr3 != null) {
			Div_Nb_React = Div_Nb_React + 1;

			Rot = Input.GetAxis ("J2_GTrigger");
			if (Rot > 0.01f) {
				if (AccRot3 < Rot) {
					AccRot3 = Rot;
				} else {
					AccRot3 = AccRot3 * AccRot_Aug;
				}
			} else {
				AccRot3 = AccRot3 * AccRot_Dim;
			}
			if (AccRot3 > AccRot_Max) {
				AccRot3 = AccRot_Max;
			}
			tr.RotateAround (tr.position, V_AxeX, - (Rot + 1) * F_Rotation * AccRot3);
		}
		if (tr4 != null) {
			Div_Nb_React = Div_Nb_React + 1;

			Rot = Input.GetAxis ("J2_DTrigger");
			if (Rot > 0.01f) {
				if (AccRot4 < Rot) {
					AccRot4 = Rot;
				} else {
					AccRot4 = AccRot4 * AccRot_Aug;
				}
			} else {
				AccRot4 = AccRot4 * AccRot_Dim;
			}
			if (AccRot4 > AccRot_Max) {
				AccRot4 = AccRot_Max;
			}
			tr.RotateAround (tr.position, V_AxeX, (Rot + 1) * F_Rotation * AccRot4);
		}



		// Mouvement sur le reacteur 1
		if (tr1 != null) {
			float Move_Hor = Input.GetAxis ("J1_GHor");
			float Move_Ver = Input.GetAxis ("J1_GVer");


			V_Move = new Vector3 (0f, Move_Ver, Move_Hor);


			if (!(Move_Hor == 0 && Move_Ver == 0)) {
				//rb.AddForceAtPosition (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Attenuation_Angulaire, V_Pos);		// force des réacteurs
				rb.AddForce (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Div_Nb_React);
				if (Distance > 2f) {
					rb.AddForce (-tr.position * F_Gravity / Distance);												// force de rappel
				}
			} else {
				rb.AddForce (-tr.position * F_Gravity * Distance / Distance_Max);
				//rb.angularVelocity = rb.angularVelocity * 0.999f;
			}
		}


		// Mouvement sur le reacteur 2
		if (tr2 != null) {
			float Move_Hor = Input.GetAxis ("J1_DHor");
			float Move_Ver = Input.GetAxis ("J1_DVer");


			V_Move = new Vector3 (0f, Move_Ver, Move_Hor);


			if (!(Move_Hor == 0 && Move_Ver == 0)) {
				//rb.AddForceAtPosition (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Attenuation_Angulaire, V_Pos);		// force des réacteurs
				rb.AddForce (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Div_Nb_React);
				if (Distance > 2f) {
					rb.AddForce (-tr.position * F_Gravity / Distance);												// force de rappel
				}
			} else {
				rb.AddForce (-tr.position * F_Gravity * Distance / Distance_Max);
				//rb.angularVelocity = rb.angularVelocity * 0.999f;
			}
		}


		// Mouvement sur le reacteur 3
		if (tr3 != null) {
			float Move_Hor = Input.GetAxis ("J2_GHor");
			float Move_Ver = Input.GetAxis ("J2_GVer");

		
			V_Move = new Vector3 (0f, Move_Ver, Move_Hor);


			if (!(Move_Hor == 0 && Move_Ver == 0)) {
				//rb.AddForceAtPosition (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Attenuation_Angulaire, V_Pos);		// force des réacteurs
				rb.AddForce (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Div_Nb_React);
				if (Distance > 2f) {
					rb.AddForce (-tr.position * F_Gravity / Distance);												// force de rappel
				}
			} else {
				rb.AddForce (-tr.position * F_Gravity * Distance / Distance_Max);
				//rb.angularVelocity = rb.angularVelocity * 0.999f;
			}
		}


		// Mouvement sur le reacteur 4
		if (tr4 != null) {
			float Move_Hor = Input.GetAxis ("J2_DHor");
			float Move_Ver = Input.GetAxis ("J2_DVer");


			V_Move = new Vector3 (0f, Move_Ver, Move_Hor);


			if (!(Move_Hor == 0 && Move_Ver == 0)) {
				//rb.AddForceAtPosition (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Attenuation_Angulaire, V_Pos);		// force des réacteurs
				rb.AddForce (V_Move * F_Move * Mathf.Sqrt (Distance_Max / (Distance + 1)) / Div_Nb_React);
				if (Distance > 2f) {
					rb.AddForce (-tr.position * F_Gravity / Distance);												// force de rappel
				}
			} else {
				rb.AddForce (-tr.position * F_Gravity * Distance / Distance_Max);
				//rb.angularVelocity = rb.angularVelocity * 0.999f;
			}
		}


		//Retour en safe zone
		if (Div_Nb_React != 0) {
			Distance = Vector3.Magnitude (tr.position);

			if (Distance > Distance_Max) {
				//On stoppe le vaisseau et on le replace dans la zone de jeu
				rb.velocity = Vecteur_Nul;
				//rb.angularVelocity = Vecteur_Nul;
				tr.position = tr.position * (Distance_Max - 0.1f) / Distance;
			}
		}
	}
}
