using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public float Speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float translation = Speed*Time.deltaTime;
		transform.position = new Vector2 (transform.position.x - translation, transform.position.y);
	}
}
