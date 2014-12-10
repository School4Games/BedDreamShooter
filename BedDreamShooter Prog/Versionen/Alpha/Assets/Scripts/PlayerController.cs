using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Update ()
	{
		// wenn rechtemaustaste gedrückt wird, wird ein Schuss am Player gespawnt 
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		} 

	}

	
	void FixedUpdate ()
	{
		//zuweisung der keys w,a,s,d || Arrowkeys & velocity

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical,0.0f);
		rigidbody2D.velocity = movement * speed;
		
		rigidbody2D.position = new Vector3 
			(
				//boundary auf x und y axe
				Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax), 

				Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax)
				);
	}
}
