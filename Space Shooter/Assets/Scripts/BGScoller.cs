using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScoller : MonoBehaviour {

    public float scollerSpeed;
    public int titleSizeZ;

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float newPosition = Mathf.Repeat(Time.time * scollerSpeed, titleSizeZ);
        this.transform.position = startPosition+ Vector3.forward * newPosition;
	}
}
