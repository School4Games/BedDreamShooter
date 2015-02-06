using UnityEngine;
using System.Collections;

public class BigGhostSpawner : MonoBehaviour
{
	public float timer;
	// BGhostspawn
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
		// random spawn on the Y-Axis 
		float randomvalue = Random.Range (-spawnValues.y, spawnValues.y);
		// spawnposition festlegen
		Vector3 spawnPosition = new Vector3 (spawnValues.x, randomvalue, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		//spawn des BGhosts an der oben angegebenen position
		Instantiate (bigGhost, spawnPosition, spawnRotation);
	}

}
