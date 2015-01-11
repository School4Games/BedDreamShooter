using UnityEngine;
using System.Collections;

public class NewSpawnfromdavide : MonoBehaviour 
{
	
	public float spawnTime;		// zeit zwischen den spawns 
	public float spawnDelay;		// zeit bevor der spwan beginnt
	public GameObject[] enemies;
	public float timer;
	public float minspawntime;
	//public Vector3 spawnValues;


	void Start ()
	{
		timer = spawnDelay;
	}

	void Spawn ()
	{
		spawnTime *= Random.Range(7f, 05f);

		
		if (spawnTime < minspawntime) 
		{
			spawnTime = minspawntime;
		}
		Debug.Log("SpawnUp");
	
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex],transform.position, transform.rotation);
	}



	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			timer = spawnTime;
			Spawn();
		}
	}

}