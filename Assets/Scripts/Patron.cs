﻿using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}
	}
}
