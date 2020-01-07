using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Obstacle_Generation : MonoBehaviour {

	public int Rayon;
	public GameObject Obstacle;
	public GameObject Start_Butt;
	public GameObject Portail;
	public float Delta_Temps_Intervalle2;
	public float Delta_Temps_Minimal2;
	public float Delta_Temps_Intervalle3;
	public float Delta_Temps_Minimal3;
	public float Delta_Temps_Intervalle4;
	public float Delta_Temps_Minimal4;
	public AudioClip Intro;
//	public GameObject Obj_Intro;
	public int Nb_Loop_Intro;
	public AudioClip Clip_Phase2;
//	public GameObject Obj_Phase2;
	public int Nb_Loop_2;
	public AudioClip Clip_Phase3;
//	public GameObject Obj_Phase3;
	public int Nb_Loop_3;
	public AudioClip Clip_Phase4;
//	public GameObject Obj_Phase4;
	public int Nb_Loop_4;
	public float Delai;
	public AudioClip Clip_Calibrage;


	private float Tps_Phase_Apprentissage;	//pas d'obstacle
	private float Tps_Phase2;				//peu d'obstacle
	private float Tps_Phase3;				//plus d'obstacles
	private float Tps_Phase4;				//nouveaux obstacles en rotation sur eux même
	private AudioSource AS;
	private float Temps;
	private float T_Origine;
	private bool Started;
	private bool stop;
	private GameObject instance_start;
	private GameObject instance_portail;
	private Transform portail_tr;


	void Start ()
	{
		Temps = Time.time;
		T_Origine = 9999999999f;
		instance_start = null;
		Started = false;
		Tps_Phase_Apprentissage = Intro.length * Nb_Loop_Intro;
		Tps_Phase2 = Clip_Phase2.length * Nb_Loop_2;
		Tps_Phase3 = Clip_Phase3.length * Nb_Loop_3;
		Tps_Phase4 = Clip_Phase4.length * Nb_Loop_4 + Delai;
		AS = GetComponent <AudioSource> ();
		portail_tr = null;
		stop = false;
	}

	void Update () {
		if (!stop & !(portail_tr == null)) {
			if (portail_tr.position.x > -80) {//(Time.time > T_Origine + Intro.length + Tps_Phase_Apprentissage + Tps_Phase2 + Tps_Phase3 + Tps_Phase4) {	//on est dans la phase de calibrage du vaisseau par rapport au portail
				//on ne genere pas d'obstacle
				stop = true;
				if (!(AS.clip == Clip_Calibrage)) {
					AS.clip = Clip_Calibrage;
					AS.loop = false;
					AS.Play ();
				}
			} else if (Time.time > T_Origine + Intro.length + Tps_Phase_Apprentissage + Tps_Phase2 + Tps_Phase3) {	//on entre dans la phase 4 : plusieurs débris instantiés en même temps

				if (!(AS.clip == Clip_Phase4)) {
					AS.clip = Clip_Phase4;
					AS.Play ();
				}

				if (Time.time > Temps) {
					float Rand_Rayon = Rayon * Random.value / 2;
					float Rand_Angle = 2 * Mathf.PI * Random.value;

					float zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
					float ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

					Vector3 V_Position = new Vector3 (-50, ypos, zpos);

					Instantiate (Obstacle, V_Position, Quaternion.identity);


					//On instantie 3 obstacles a la fois
					Rand_Rayon = Rayon * Random.value / 2;
					Rand_Angle = 2 * Mathf.PI * Random.value;

					zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
					ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

					V_Position = new Vector3 (-50, ypos, zpos);

					Instantiate (Obstacle, V_Position, Quaternion.identity);


					Rand_Rayon = Rayon * Random.value / 3;
					Rand_Angle = 2 * Mathf.PI * Random.value;

					zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
					ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

					V_Position = new Vector3 (-50, ypos, zpos);

					Instantiate (Obstacle, V_Position, Quaternion.identity);


					Temps = Time.time + Delta_Temps_Minimal4 + (int)((Delta_Temps_Intervalle4 - Delta_Temps_Minimal4) * Random.value);
				}
			} else if (Time.time > T_Origine + Intro.length + Tps_Phase_Apprentissage + Tps_Phase2) {		//on entre dans la phase 3 : plus de debris

				if (!(AS.clip == Clip_Phase3)) {
					AS.clip = Clip_Phase3;
					AS.Play ();
				}

				if (Time.time > Temps) {
					float Rand_Rayon = Rayon * Random.value;
					float Rand_Angle = 2 * Mathf.PI * Random.value;

					float zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
					float ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

					Vector3 V_Position = new Vector3 (-50, ypos, zpos);

					Instantiate (Obstacle, V_Position, Quaternion.identity);


					Temps = Time.time + Delta_Temps_Minimal3 + (int)((Delta_Temps_Intervalle3 - Delta_Temps_Minimal3) * Random.value);
				}
			} else if (Time.time > T_Origine + Intro.length + Tps_Phase_Apprentissage) { 	//on entre dans la phase 2 : quelques debris

				if (!(AS.clip == Clip_Phase2)) {
					AS.clip = Clip_Phase2;
					AS.loop = true;
					AS.Play ();
				}

				if (Time.time > Temps) {
					float Rand_Rayon = Rayon * Random.value;
					float Rand_Angle = 2 * Mathf.PI * Random.value;

					float zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
					float ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

					Vector3 V_Position = new Vector3 (-50, ypos, zpos);

					Instantiate (Obstacle, V_Position, Quaternion.identity);


					Temps = Time.time + Delta_Temps_Minimal2 + (int)((Delta_Temps_Intervalle2 - Delta_Temps_Minimal2) * Random.value);
				}
			} /*else if (!(AS.clip == Intro)) {
			//on ne genere pas d'obstacle
			AS.clip = Intro;
			AS.loop = false;
			AS.Play ();
			}*/
		}

		if (!Started & Time.time > Temps) {

			float Rand_Rayon = Rayon;
			float Rand_Angle = 2 * Mathf.PI * Random.value;

			float zpos = Rand_Rayon * Mathf.Cos (Rand_Angle);
			float ypos = Rand_Rayon * Mathf.Sin (Rand_Angle);

			Vector3 V_Position = new Vector3 (-50, ypos, zpos);

			instance_start = Instantiate (Start_Butt, V_Position, Quaternion.identity);

			Temps = Time.time + 5;
		}

		if (!(instance_start == null)) {
			if (instance_start.name == "Start Pressed" & !Started) {
				Started = true;
				T_Origine = Time.time;	//début des obstacles
				instance_portail = Instantiate (Portail);
				portail_tr = instance_portail.GetComponent <Transform> ();

				AS.clip = Intro;
				AS.loop = false;
				AS.Play ();
			}
		}
	}
}
