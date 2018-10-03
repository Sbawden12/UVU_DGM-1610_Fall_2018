using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D Player;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay
	public float RespawnDelay;


	//Point Penalty Death
	public int PointPenaltyOnDeath;

	// Store Gravity Value

	private float GravityStore;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		StarCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		// Generate Death Particle
		Instantiate (DeathParticle, player.transform.position, player.transform.rotation);
		// Hide Player
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
		player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// DebugMessage
		Debug.Log ("Player Respawn");
		// Respawn Delay
		yeild return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		player.GetComponent<Rigidbody2D>().gravityScale = GravityStore;

	}
}
