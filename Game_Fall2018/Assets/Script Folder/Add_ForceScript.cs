﻿using UnityEngine;

public class Add_ForceScript : MonoBehaviour {
    public Rigidbody rb;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        rb.AddForce(0, 100, 0);
	}
}
