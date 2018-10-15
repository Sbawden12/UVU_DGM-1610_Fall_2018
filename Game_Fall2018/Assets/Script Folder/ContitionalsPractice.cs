using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContitionalsPractice : MonoBehaviour {

	public string Baseball;

	// Use this for initialization
	void Start () {

		if(Baseball == " Homerun ")
			print("Hit a" + Baseball);

		else if(Baseball == " Single ")
			print("Hit a" + Baseball);
			
		else if(Baseball == " Double ")
			print("Hit a" + Baseball);

		else if(Baseball == " Triple ")
			print("Hit a" + Baseball);

		else
			print("Strike Out" + Baseball);				
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
