using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject bolt;
    public Transform shotSpawn;
    public float fireRate;
    public float fireDelay;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = this.GetComponent<AudioSource>();
        InvokeRepeating("fire", fireDelay, fireRate);
	}

    void fire()
    {
        Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
