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
		//player = FindObjectOfType<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		// Generate Death Particle
		Instantiate (DeathParticle, Player.transform.position, Player.transform.rotation);
		// Hide Player
		//player.enabled = false;
		Player.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = Player.GetComponent<Rigidbody2D>().gravityScale;
		Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// DebugMessage
		Debug.Log ("Player Respawn");
		// Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		Player.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Maatch PCs transform position
		Player.transform.position = CurrentCheckPoint.transform.position;
		//Show PC
		// PC.enabled = true;
		Player.GetComponent<Renderer> ().enabled = true;
		// Spawn PC
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
		
	}
}
