using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	//GameObject enemey
	public GameObject enemey;
	//Spawn punkt
	public Vector3 spawnValues;
	//Wie viele enemys pro wave
	public int enemeyCount;
	//Zeit bis zum nächsten enemey
	public float spawnWait;
	//Zeit bis das erste mal ein Gegner kommt
	public float startWait;
	//Zeit bis zur nächsten wave
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{

	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < enemeyCount; i++)
			{


				float randomvalue = Random.Range (-spawnValues.y, spawnValues.y);
				Vector3 spawnPosition = new Vector3 (spawnValues.x, randomvalue, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemey, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return  new WaitForSeconds (waveWait);
			if (spawnWait >= spawnWait)
			{
				spawnWait = spawnWait -0.4f;
				if(spawnWait < 0)
				{
					spawnWait = 4;
				}
			}
			/*if (enemeyCount >= enemeyCount)
			{
				enemeyCount = enemeyCount + 1;
			}*/
		}
	}
}