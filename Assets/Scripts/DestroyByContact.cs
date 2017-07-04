using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else
        {
            Debug.Log("Can't find gameController script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.numDest++;
        gameController.updateKillRate();
        if(other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.AddScore(-1);
            gameController.numDest--;
            gameController.updateKillRate();
            gameController.GameOver();
        }
        
        gameController.AddScore(1);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
