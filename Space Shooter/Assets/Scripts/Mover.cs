using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Speed;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * Speed;
        Debug.Log(this.transform.forward.ToString());
	}
	
}
