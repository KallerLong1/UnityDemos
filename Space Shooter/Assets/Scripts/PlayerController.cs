﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rb;
    private float nextFire;
    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb = GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        rb.velocity = movement * Speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, -rb.velocity.x * tilt);

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }


}
