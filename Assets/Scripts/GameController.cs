﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public int swigs;
	public Text swigText;
	public Text scoreText;
	public int maxPatrons;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] patronObjects;

	public int currentNumberOfDemons = 0;

	public Text shankYouText;
	public Text gameOverText;
	public Text restartText;

	private int score = 0;
	public int patronCounter = 0;
	private bool restart;
	private int maxSwigs;

	// Use this for initialization
	void Start () {
		maxSwigs = swigs;

		restart = false;

		UpdateSwigText ();
		UpdateScoreText ();

		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R))
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

//		Debug.Log (currentNumberOfDemons + "/" + patronCounter);
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		
		while (true)
		{
			if (patronCounter < maxPatrons)
			{
				Vector3 spawnPosition = new Vector3 (20f, 3f, 9f);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (patronObjects[Random.Range (0, patronObjects.Length)], spawnPosition, spawnRotation);

				patronCounter++;
				
				yield return new WaitForSeconds (spawnWait);
			}
			
			yield return new WaitForSeconds (waveWait);

			if (swigs == 0)
			{
				yield return new WaitForSeconds (5);

				shankYouText.enabled = true;
				gameOverText.enabled = true;
				restartText.enabled = true;

				restart = true;

				GameObject.FindGameObjectWithTag ("Player").SetActive (false);

				break;
			}
		}
	}

	public void TakeSwig() {
		swigs -= 1;
		UpdateSwigText();
	}

	public void AddScore() {
		score += 100;
		UpdateScoreText ();
		patronCounter--;
		currentNumberOfDemons--;
	}

	public void DetractScore() {
		score -= 150;
		UpdateScoreText ();
		patronCounter--;
	}

	void UpdateSwigText() {
		swigText.text = "Swigs Left: " + swigs + " / " + maxSwigs;
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score;
	}
}
