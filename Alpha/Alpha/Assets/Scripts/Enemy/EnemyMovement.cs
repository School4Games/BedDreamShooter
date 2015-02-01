using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public float Speed;
	public Vector2 movementDirection = new Vector2(-1,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();

	}
	/*void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}*/
	void Move()
	{
		float translation = Speed*Time.deltaTime;

		//MoveOn(new Vector2(-translation,0));

		MoveOn (movementDirection * translation);
	}
	public void MoveOn(Vector2 distance)
	{
		transform.Translate (distance);
	}
}
