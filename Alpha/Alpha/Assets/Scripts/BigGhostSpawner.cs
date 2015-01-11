﻿using UnityEngine;
using System.Collections;

public class BigGhostSpawner : MonoBehaviour
{
	public float timer;
	
	public GameObject bigGhost;
	public Vector3 spawnValues;
	public float startdelay;
	public float spawndelay;
	
	void Start ()
	{
		SpawnWaves ();
		
		timer = startdelay;
	}
	
	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			timer = spawndelay;
			SpawnWaves ();
		}
	}
	
	void SpawnWaves ()
	{
		float randomvalue = Random.Range (-spawnValues.y, spawnValues.y);
		Vector3 spawnPosition = new Vector3 (spawnValues.x, randomvalue, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bigGhost, spawnPosition, spawnRotation);
	}

}
