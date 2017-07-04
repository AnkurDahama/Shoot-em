using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour {

    public GameObject hazards;
    public Vector3 InitValues;
    public float ShootWait;
    public GUIText scoreText;
    public GUIText gameOverText;
    public GUIText killRateText;
    private int score;
    private float killRate;
    private bool isAlive = true;
    public float numShots = 0.0F;
    public float numDest = 0.0F;

	// Use this for initialization
	void Start () {
       StartCoroutine(ThrowRock());
        score = 0;
        UpdateScore();
        gameOverText.text = "";
        killRateText.text = "";
        if(Input.GetKeyDown(KeyCode.C))
        {

        }
	}

    IEnumerator ThrowRock()
    {
        while (isAlive == true)
        {
            for(int i = 0; i <= 10; i++)
            {
                Vector3 where = new Vector3(UnityEngine.Random.Range(-15.0F, 15.0F), 0, InitValues.z);
                Quaternion angle = hazards.transform.rotation;
                Instantiate(hazards, where, angle);
                if(isAlive == true)
                    numShots++;
                updateKillRate();
                yield return new WaitForSeconds(ShootWait);
            }
            if(ShootWait > 0.4)
                ShootWait -= 0.1F;
        }
       
    }

    public void AddScore(int newscore)
    {
        score += newscore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Kills: " + score;
    }

    public void updateKillRate()
    {
        killRate = (numDest / numShots) * 100.0F;
        killRateText.text = "Kill Rate: " + Math.Round(killRate, 2) + " %";
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverText.text = "Game Over Bitch!";
    }
}
