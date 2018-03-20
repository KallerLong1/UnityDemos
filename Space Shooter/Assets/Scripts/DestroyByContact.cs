using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int scoreValue;


    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("We can't find 'Gamecontroller' object.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
        else if (Explosion != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
