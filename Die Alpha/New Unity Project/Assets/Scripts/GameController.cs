using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject Slimer;
	public Vector3 spawnValues;
	
	void Start ()
	{
		SpawnWaves ();
	}
	
	void SpawnWaves ()
	{
		float randomvalue = Random.Range (-spawnValues.y, spawnValues.y);
		Vector3 spawnPosition = new Vector3 (spawnValues.x, randomvalue, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (Slimer,spawnPosition, spawnRotation);
	}
}