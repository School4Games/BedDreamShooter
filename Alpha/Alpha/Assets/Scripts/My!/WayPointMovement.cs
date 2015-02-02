using UnityEngine;
using System.Collections;

public class WayPointMovement : MonoBehaviour
{

	//public int speed;
	//public Vector3 moveValues;

	// Use this for initialization
	public Vector3 pointB;
	
	IEnumerator Start()
	{
		var pointA = transform.position;
		while (true) 
		
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) 
		
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	// Update is called once per frame
	void Update () 
	{
		WaypointMove ();	

	}
	void WaypointMove()
	{
		//float translation = speed * Time.deltaTime;
		//transform.position = new Vector2 (transform.position.x, transform.position.y - translation);

		/*float randomvalue = Random.Range (-moveValues.y, moveValues.y);
		Vector3 spawnPosition = new Vector2 (moveValues.x, randomvalue);
		Quaternion spawnRotation = Quaternion.identity;*/
	}
}
